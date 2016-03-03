using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundManager : MonoBehaviour {

	public Text m_TimerCanvas;

	public bool MatchStarted = false;
	float time;
    public float RoundCountDown;
    public float PreRoundCountDown;
	int PlayerScore;


	// Use this for initialization
    void Start()
    {
        StartCoroutine(RoundIntro(Time.deltaTime));
    }
	// Update is called once per frame
	void Update () {
   		
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
		int[] k = new int[2];
		StartCoroutine(TurnOffPlayerControls());

		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < players.Length; i++) {
			k[i] = players [i].GetComponent<player1Controler> ().deathCounter;
		}
		for (int j = 0; j < k.Length - 1; j++) {
			if (k [j] < k [j + 1]) {
				PlayerScore = k [j];
				m_TimerCanvas.text = "Player2 win";
			} else if (k [j] > k [j + 1]) {
				PlayerScore = k [j + 1];
				m_TimerCanvas.text = "Player1 win";
			} else {
				m_TimerCanvas.text = "TIE wind";

			}
		}
    }

	IEnumerator TurnOnPlayerControls()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		for (int i = 0; i < players.Length; i++) {
			players [i].GetComponent<player1Controler> ().ScaleCheck ();
			players [i].GetComponent<player1Controler> ().enabled = true;
			yield return new WaitForSeconds (0.2f);

		}
	}
	IEnumerator TurnOffPlayerControls()
	{
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		yield return new WaitForSeconds(0.2f);
		for (int i = 0; i < players.Length; i++) {
			players [i].GetComponent<player1Controler> ().ScaleCheck ();
			players [i].GetComponent<player1Controler> ().enabled = false;
		}
	}
}
