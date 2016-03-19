using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoundManager : MonoBehaviour
{

    public Text m_TimerCanvas;

    public bool MatchStarted = false;
    float time;
    public float RoundCountDown;
    public float PreRoundCountDown;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(RoundIntro(Time.deltaTime));
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RoundIntro(float CurrentTime)
    {
        while (PreRoundCountDown >= 0)
        {
            StartCoroutine(TurnOffPlayerControls());
            PreRoundCountDown -= CurrentTime;
            m_TimerCanvas.text = "Starting In \n" + PreRoundCountDown.ToString("f2");
            yield return null;
        }
        MatchStarted = true;
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
        MatchStarted = false;
        RoundEnd();
    }

    void RoundEnd()
    {
        int[] deaths = new int[2];
        int[] PlayerNum = new int[2];
        StartCoroutine(TurnOffPlayerControls());

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
                m_TimerCanvas.text = "Player " + PlayerNum[j].ToString("f0") + " win";
            }
            else if(deaths[j]>deaths[j+1])
            {
                m_TimerCanvas.text = "Player " + PlayerNum[j+1].ToString("f0") + " win";
            }
            else
            {
                m_TimerCanvas.text = "Tied";
            }
        }
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
