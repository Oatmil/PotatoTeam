using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{

    public Text m_TimerCanvas;

    GameObject[] PlayersList = new GameObject[2];
    Vector3 Player1Pos;
    Vector3 Player2Pos;
    public int Player1Score;
    public int Player2Score;

    public int RoundCounter ;
    public bool MatchStarted = false;
    public float RoundCountDown;
    public float PreRoundCountDown;
    float tempRound;
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
    }
    void Start()
    {
        tempPreRound = PreRoundCountDown;
        tempRound = RoundCountDown;
        for (int i = 0; i < 2; i++)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("Player");
            {
                if(temp.GetComponent<player1Controler>().PlayerNumber == 1)
                {
                    PlayersList[1] = temp;
                    Player1Pos = PlayersList[1].transform.position;
                }
                else if (temp.GetComponent<player1Controler>().PlayerNumber == 2)
                {
                    PlayersList[2] = temp;
                    Player2Pos = PlayersList[2].transform.position;

                }
            }
        }
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
        if (RoundCounter < 3)
        {
            RoundCountDown = tempRound;
            PreRoundCountDown = tempPreRound;
            MatchStarted = false;
            m_RoundOverImage.enabled = false;
            m_Player1WinBanner.enabled = false;
            m_Player2WinBanner.enabled = false;
            StartCoroutine(RoundIntro(CurrentTime));
        }
    }

    void RoundEnd()
    {
        int[] deaths = new int[2];
        int[] PlayerNum = new int[2];

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            deaths[i] = players[i].GetComponent<player1Controler>().deathCounter;
            PlayerNum[i] = players[i].GetComponent<player1Controler>().PlayerNumber;
        }
        for (int j = 0; j < deaths.Length - 1; j++)
        {
            if (deaths[j] < deaths[j + 1])
            {
                m_TimerCanvas.text = "Round " + RoundCounter.ToString() + "\n Winner Is "+"Player " + PlayerNum[j].ToString("f0");
                CheckPlayerWinner(PlayerNum[j]);
                players[j].GetComponent<WinLoseAnimationController>().Win = true;
                players[j + 1].GetComponent<WinLoseAnimationController>().Lose = true;

            }
            else if(deaths[j]>deaths[j+1])
            {
                m_TimerCanvas.text = "Round " + RoundCounter.ToString() + "\n Winner Is "+"Player " + PlayerNum[j + 1].ToString("f0");
                CheckPlayerWinner(PlayerNum[j + 1]);
                players[j].GetComponent<WinLoseAnimationController>().Lose = true;
                players[j + 1].GetComponent<WinLoseAnimationController>().Win = true;
            }
            else
            {
                m_TimerCanvas.text = "Tied";
            }
        }
    }

    void CheckPlayerWinner(int playerNumber)
    {
        if (playerNumber == 1)
        {
            m_Player1WinBanner.enabled = true;
        }
        else if (playerNumber == 2)
        {
            m_Player2WinBanner.enabled = true;
        }
        audio.clip = m_CelebrationAudio;
        audio.Play();
    }


    IEnumerator TurnOnPlayerControls()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<player1Controler>().enabled = true;
            yield return new WaitForSeconds(0.2f);

        }
    }
    IEnumerator TurnOffPlayerControls()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<player1Controler>().ScaleCheck();
            players[i].GetComponent<player1Controler>().enabled = false;
        }
    }
}
