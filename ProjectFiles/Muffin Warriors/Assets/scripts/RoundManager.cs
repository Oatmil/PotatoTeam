using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{

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
    public Image m_StartRoundImage;
    public Image m_RoundOverImage;
    public Image m_Player1WinBanner;
    public Image m_Player2WinBanner;

    public AudioClip m_StartRoundAudio;
    public AudioClip m_Last10Seconds;
    public AudioClip m_RoundEndAudio;
    public AudioClip m_CelebrationAudio;

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
    }
    void Start()
    {
        tempPreRound = PreRoundCountDown;
        tempRound = RoundCountDown;
        StartCoroutine(TurnOnPlayerControls());
        StartCoroutine(RoundIntro(Time.deltaTime));
    }
    // Update is called once per frame
    void Update()
    {
        if (PreRoundCountDown < 1.4f && MatchStarted == false)
        {
            audio.clip = m_StartRoundAudio;
            m_StartRoundImage.enabled = true;
            if (audio.isPlaying == false)
            {
                audio.Play();
            }
        }
        if (MatchStarted == true)
        {
            m_StartRoundImage.enabled = false;
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
        while (PreRoundCountDown >= 0)
        {
            StartCoroutine(TurnOffPlayerControls());
            PreRoundCountDown -= CurrentTime;
            m_TimerCanvas.text = "Round " + (RoundCounter + 1).ToString()+ "\n Starting in \n" +PreRoundCountDown.ToString("f2");
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
            StartCoroutine(TurnOnPlayerControls());
            RoundCountDown -= CurrentTime;
            m_TimerCanvas.text = "timer : \n" + RoundCountDown.ToString("f2");
            yield return null;
        }
        m_RoundOverImage.enabled = true;
        audio.clip = m_RoundEndAudio;
        if (audio.isPlaying == false)
        {
            audio.Play();
        }
        StartCoroutine(TurnOffPlayerControls());

        m_TimerCanvas.text = "The \n Results \n Are \n In";
        yield return new WaitForSeconds(3.0f);
        RoundEnd();
        yield return new WaitForSeconds(5.0f);
        if (Player1Score == 2)
        {
            EndGamePlayerWinner(1);
        }
        else if (Player2Score == 2)
        {
            EndGamePlayerWinner(2);
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
        m_RoundOverImage.enabled = false;
        m_Player1WinBanner.enabled = false;
        m_Player2WinBanner.enabled = false;
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
                m_TimerCanvas.text = "Round " + RoundCounter.ToString() + "\n Player " + PlayerNum[j].ToString("f0") + "\n Takes It";
                PlayersList[j].GetComponent<WinLoseAnimationController>().Win = true;
                CheckPlayerWinner(PlayerNum[j]);
                PlayersList[j + 1].GetComponent<WinLoseAnimationController>().Lose = true;
            }
            else if(deaths[j]>deaths[j+1])
            {
                m_TimerCanvas.text = "Round " + RoundCounter.ToString() + "\n Player " + PlayerNum[j + 1].ToString("f0") + "\n Takes It";
                PlayersList[j].GetComponent<WinLoseAnimationController>().Lose = true;
                CheckPlayerWinner(PlayerNum[j + 1]);
                PlayersList[j + 1].GetComponent<WinLoseAnimationController>().Win = true;
            }
            else
            {
                m_TimerCanvas.text = "Tied";
            }
            deaths[j] = 0;
            deaths[j + 1] = 0;
        }
    }

    void EndGamePlayerWinner(int playerNumber)
    {
        if (playerNumber == 1)
        {
            m_Player1WinBanner.enabled = true;
            Player1Score += 1;
        }
        else if (playerNumber == 2)
        {
            m_Player2WinBanner.enabled = true;
            Player2Score += 1;
        }
        audio.clip = m_CelebrationAudio;
        audio.Play();
    }

    void CheckPlayerWinner(int playerNumber)
    {
        if (playerNumber == 1)
        {
            Player1Score += 1;
        }
        else if (playerNumber == 2)
        {
            Player2Score += 1;
        }
    }
    
    IEnumerator TurnOnPlayerControls()
    {
        for (int i = 0; i < PlayersList.Length; i++)
        {
            PlayersList[i].GetComponent<player1Controler>().enabled = true;
            yield return new WaitForSeconds(0.2f);
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
}
