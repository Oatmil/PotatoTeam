using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{
    ResetButton m_managerScript;
    BgmSound m_BGMAudio;
	public Text m_TimerCanvas;

	GameObject[] PlayersList = new GameObject[2];
	Vector3 Player1Pos; // used for resetting purpose
	Vector3 Player2Pos;
	public int Player1Score;
	public int Player2Score;

	public int RoundCounter ;
	public bool MatchStarted = false;
	public float RoundCountDown;
	public float PreRoundCountDown;
	float tempRound; //used for resetting purpose
	float tempPreRound;

	AudioSource audio;
	public GameObject m_ReadyRoundImage;
    public GameObject m_StartRoundImage;
    public GameObject m_RoundOverImage;
    public GameObject m_Player1WinBanner;
    public GameObject m_Player2WinBanner;
    public GameObject m_PlayerDrawBanner;

	public AudioClip m_StartRoundAudio;
	public AudioClip m_Last10Seconds;
	public AudioClip m_RoundEndAudio;
	public AudioClip m_CelebrationAudio;

    int PrevLight;
    EnvironmentParticle m_Particle;
    HazardScript m_Hazard;
    Environment_BottleAndJar[] m_moveObject = new Environment_BottleAndJar[40];

    public int m_TotalDeaths;

	void Awake()
	{
		audio = GetComponent<AudioSource>();
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < players.Length; i++)
		{
			{
				if (players[i].GetComponent<player1Controler>().PlayerNumber == 1)
				{
					PlayersList[0] = players[i];
					Player1Pos = PlayersList[0].transform.position;
				}
				else if (players[i].GetComponent<player1Controler>().PlayerNumber == 2)
				{
					PlayersList[1] = players[i];
					Player2Pos = PlayersList[1].transform.position;

				}
			}
		}
        m_Particle = GameObject.FindGameObjectWithTag("EnvironmentParticle").GetComponent<EnvironmentParticle>();
        m_Hazard = GameObject.FindGameObjectWithTag("EnvironmentHazard").GetComponent<HazardScript>();
	}
	void Start()
	{
        m_BGMAudio = GameObject.FindGameObjectWithTag("Sounds").GetComponent<BgmSound>();
		tempPreRound = PreRoundCountDown;
		tempRound = RoundCountDown;
		StartCoroutine(TurnOnPlayerControls());
		StartCoroutine(RoundIntro(Time.deltaTime));
        m_managerScript = transform.GetComponent<ResetButton>();
        for (int i = 0; i < m_moveObject.Length; i++)
        {
            GameObject[] tempObject = GameObject.FindGameObjectsWithTag("EnvironmentObject");
            m_moveObject[i] = tempObject[i].GetComponent<Environment_BottleAndJar>();
        }
        
	}

	// Update is called once per frame
	void Update()
	{

		if (PreRoundCountDown > 1.0f && MatchStarted == false)
		{
			m_ReadyRoundImage.SetActive(true);
		}
		if (PreRoundCountDown < 1.0f && MatchStarted == false)
		{
            m_ReadyRoundImage.SetActive(false);
			audio.clip = m_StartRoundAudio;
            m_StartRoundImage.SetActive(true);
			if (audio.isPlaying == false)
			{
				audio.Play();
			}
		}
		if (MatchStarted == true)
		{
            m_StartRoundImage.SetActive(false);
		}

		if (RoundCountDown <= 10 && RoundCountDown >1.0f)
		{
			audio.clip = m_Last10Seconds;
			if (audio.isPlaying == false)
			{
				audio.Play();
			}
		}
		else if (RoundCountDown < 1.0f)
		{

		}

	}

	IEnumerator RoundIntro(float CurrentTime)
	{
        RandomStageLights();
		while (PreRoundCountDown >= 0)
		{
			StartCoroutine(TurnOffPlayerControls());
            PreRoundCountDown -= CurrentTime;
            
			m_TimerCanvas.text = "READY!";
			yield return null;
		}
		MatchStarted = true;
		RoundCounter += 1;
		StartCoroutine(RoundRunning(CurrentTime));
	}

	IEnumerator RoundRunning(float CurrentTime)
	{
		while (RoundCountDown >= 0)
		{
            if (RoundCountDown <= 25)
            {
                m_Hazard.SetHazard(PrevLight); // begin hazard
            }
            if (Time.timeScale == 0)
            {
                pausePlayers();
                RoundCountDown -= 0;
            }
            else
            {
                unpausePlayers();
                RoundCountDown -= CurrentTime;
            }
			m_TimerCanvas.text = RoundCountDown.ToString("f2");
			yield return null;
		}
        m_Hazard.SetHazard(5); // stop the hazard
        m_RoundOverImage.SetActive(true);
		audio.clip = m_RoundEndAudio;
		if (audio.isPlaying == false)
		{
			audio.Play();
		}
		StartCoroutine(TurnOffPlayerControls());

		yield return new WaitForSeconds(2.0f);
		RoundEnd();
		yield return new WaitForSeconds(3.0f);
        ResetBottles();
		if (Player1Score == 2)
		{
			EndGamePlayerWinner(1);
            yield return new WaitForSeconds(2.0f);
            m_managerScript.GameOver(m_TotalDeaths);
		}
		else if (Player2Score == 2)
		{
			EndGamePlayerWinner(2);
            yield return new WaitForSeconds(2.0f);
            m_managerScript.GameOver(m_TotalDeaths);
            
		}
		else if (Player1Score != 2 && Player2Score != 2)
		{
			ResetRound(CurrentTime);
		}
	}
	void ResetRound(float CurrentTime)
	{
		RoundCountDown = tempRound;
		PreRoundCountDown = tempPreRound;
		MatchStarted = false;
        m_RoundOverImage.SetActive(false);
        m_Player1WinBanner.SetActive(false);
        m_Player2WinBanner.SetActive(false);
        m_PlayerDrawBanner.SetActive(false);
		StartCoroutine(RoundIntro(CurrentTime));
		int[] PlayerNum = new int[2];
		for (int i = 0; i < PlayersList.Length; i++)
		{
			PlayersList[i].GetComponent<WinLoseAnimationController>().Reset = true;
			if (PlayersList[i].GetComponent<player1Controler>().PlayerNumber == 1)
			{
				PlayersList[0].transform.position = Player1Pos;
			}
			else if (PlayersList[i].GetComponent<player1Controler>().PlayerNumber == 2)
			{
				PlayersList[1].transform.position = Player2Pos;
			}
			PlayersList[i].GetComponent<player1Controler>().deathCounter = 0;
		}
	}

    public void SetRematch()
    {
        Player1Score = 0;
        Player2Score = 0;
        m_TotalDeaths = 0;

        RoundCountDown = tempRound;
        PreRoundCountDown = tempPreRound;
        MatchStarted = false;
        m_RoundOverImage.SetActive(false);
        m_Player1WinBanner.SetActive(false);
        m_Player2WinBanner.SetActive(false);
        m_PlayerDrawBanner.SetActive(false);
        StartCoroutine(RoundIntro(Time.deltaTime));
        int[] PlayerNum = new int[2];
        for (int i = 0; i < PlayersList.Length; i++)
        {
            PlayersList[i].GetComponent<WinLoseAnimationController>().Reset = true;
            if (PlayersList[i].GetComponent<player1Controler>().PlayerNumber == 1)
            {
                PlayersList[0].transform.position = Player1Pos;
            }
            else if (PlayersList[i].GetComponent<player1Controler>().PlayerNumber == 2)
            {
                PlayersList[1].transform.position = Player2Pos;
            }
            PlayersList[i].GetComponent<player1Controler>().deathCounter = 0;
        }
    }

	void RoundEnd()
	{
		int[] deaths = new int[2];
		int[] PlayerNum = new int[2];

		for (int i = 0; i < PlayersList.Length; i++)
		{
			deaths[i] = PlayersList[i].GetComponent<player1Controler>().deathCounter;
			PlayerNum[i] = PlayersList[i].GetComponent<player1Controler>().PlayerNumber;
		}
		for (int j = 0; j < deaths.Length - 1; j++)
		{
			if (deaths[j] < deaths[j + 1])
			{
				//m_TimerCanvas.text = "Round " + RoundCounter.ToString() + "\n Player " + PlayerNum[j].ToString("f0") + "\n Takes It";
				PlayersList[j].GetComponent<WinLoseAnimationController>().Win = true;
				CheckPlayerWinner(PlayerNum[j]);
				PlayersList[j + 1].GetComponent<WinLoseAnimationController>().Lose = true;
			}
			else if(deaths[j]>deaths[j+1])
			{
				//m_TimerCanvas.text = "Round " + RoundCounter.ToString() + "\n Player " + PlayerNum[j + 1].ToString("f0") + "\n Takes It";
				PlayersList[j].GetComponent<WinLoseAnimationController>().Lose = true;
				CheckPlayerWinner(PlayerNum[j + 1]);
				PlayersList[j + 1].GetComponent<WinLoseAnimationController>().Win = true;
			}
			else
			{
				//m_TimerCanvas.text = "Tied";
                m_PlayerDrawBanner.SetActive(true);
			}
            m_TotalDeaths += deaths[j] + deaths[j + 1];
			deaths[j] = 0;
			deaths[j + 1] = 0;
		}
	}

	void EndGamePlayerWinner(int playerNumber)
	{
		if (playerNumber == 1)
		{
            m_Player1WinBanner.SetActive(true);
			Player1Score += 1;
		}
		else if (playerNumber == 2)
		{
            m_Player2WinBanner.SetActive(true);
			Player2Score += 1;
		}
        audio.clip = m_CelebrationAudio;
        audio.Play();
	}

	void CheckPlayerWinner(int playerNumber)
	{
		if (playerNumber == 1)
		{
            m_Player1WinBanner.SetActive (true);
			Player1Score += 1;
		}
		else if (playerNumber == 2)
		{
            m_Player2WinBanner.SetActive(true);
			Player2Score += 1;
		}
	}

	IEnumerator TurnOnPlayerControls()
	{
		for (int i = 0; i < PlayersList.Length; i++)
		{
			PlayersList[i].GetComponent<player1Controler>().enabled = true;
			yield return new WaitForSeconds(0.1f);
		}
	}
	IEnumerator TurnOffPlayerControls()
	{
		yield return new WaitForSeconds (0.5f);
		for (int i = 0; i < PlayersList.Length; i++)
		{
			PlayersList[i].GetComponent<player1Controler>().ResetCharacter();
			PlayersList[i].GetComponent<player1Controler>().ScaleCheck();
			PlayersList[i].GetComponent<player1Controler>().enabled = false;
		}

	}

    void pausePlayers()
    {
        for (int i = 0; i < PlayersList.Length; i++)
        {
            PlayersList[i].GetComponent<player1Controler>().enabled = false;
        }
    }
    void unpausePlayers()
    {
        for (int i = 0; i < PlayersList.Length; i++)
        {
            PlayersList[i].GetComponent<player1Controler>().enabled = true;
        }
    }

    void RandomStageLights()
    {
        int randomlight;
        do
        {
            randomlight = Random.Range(0, 5);
        } while (randomlight == PrevLight);

        PrevLight = randomlight;
        m_Particle.SetEnvironment(randomlight);
        m_BGMAudio.SetAudio(randomlight);

        int j = randomlight * 4;
        GameObject[] tempObject = GameObject.FindGameObjectsWithTag("EnvironmentLights");
        for (int i = 0; i < tempObject.Length; i++)
        {
            Light lit = tempObject[i].GetComponent<Light>();
            lit.color = m_lightColors[i + j];
            lit.intensity = m_lightIntensity[i + j];
        }
    }

    void ResetBottles()
    {
        for (int i = 0; i < m_moveObject.Length; i++)
        {
            if (m_moveObject[i] != null)
                m_moveObject[i].reSetPos();
        }
    }

    // lighting setting for editor and saving
    public Color[] m_lightColors = new Color[20];
    [HideInInspector]
    public float[] m_lightIntensity = new float[20];
    public int m_EnvironmentNumber;
    
    public void PreviewEnvironment()
    {
        int j = m_EnvironmentNumber * 4;
        GameObject[] tempObject = GameObject.FindGameObjectsWithTag("EnvironmentLights");
        for (int i = 0; i < tempObject.Length; i++)
        {
            Light lit = tempObject[i].GetComponent<Light>();
            lit.color = m_lightColors[i+j];
            lit.intensity = m_lightIntensity[i+ j];
        }
    }

    public void SaveEnvironment()
    {
        int j = m_EnvironmentNumber * 4;
        GameObject[] tempObject = GameObject.FindGameObjectsWithTag("EnvironmentLights");
        for (int i = 0; i < tempObject.Length; i++)
        {
            Light lit = tempObject[i].GetComponent<Light>();
            m_lightColors[i+ j] = lit.color;
            m_lightIntensity[i+ j] = lit.intensity;
        }
    }

    public int CheckingCurrentScore(int m_PlayerNum) // check enemy deaths as own score
    {
        int m_ReturnValue = 0;

        int PlayerNum = 0;

        for (int i = 0; i < PlayersList.Length; i++)
        {
            PlayerNum = PlayersList[i].GetComponent<player1Controler>().PlayerNumber;
            if (PlayerNum == m_PlayerNum)
            {
                m_ReturnValue = PlayersList[i].GetComponent<player1Controler>().deathCounter;
                return m_ReturnValue;
            }
        }
        return 0;
       // Debug.Log("return value " + m_ReturnValue);
       
    }
}
