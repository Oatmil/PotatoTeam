using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMenuController : MonoBehaviour {

    public Image m_player1Control;
    public Image m_player2Control;

    public GameObject m_player1;
    public GameObject m_player2;

    public float m_FadeDelay;
    float timePlayer1;
    float timePlayer2;

    Vector3 player1Pos;
    Vector3 player2Pos;
	// Use this for initialization
	void Start () {
        player1Pos = m_player1.transform.position;
        player2Pos = m_player2.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (player1Pos != m_player1.transform.position)
        {
            m_player1Control.GetComponent<Image>().CrossFadeAlpha(0,0.25f, true);
            timePlayer1 += Time.deltaTime;
            if (timePlayer1 >= m_FadeDelay)
            {
                player1Pos = m_player1.transform.position;
                timePlayer1 = 0;
            }
        }
        if (player1Pos == m_player1.transform.position)
        {

            m_player1Control.GetComponent<Image>().CrossFadeAlpha(1,0.5f, true);
        }

        if (player2Pos != m_player2.transform.position)
        {
            m_player2Control.GetComponent<Image>().CrossFadeAlpha(0, 0.25f, true);
            timePlayer2 += Time.deltaTime;
            if (timePlayer2 >= m_FadeDelay)
            {
                player2Pos = m_player2.transform.position;
                timePlayer2 = 0;
            }
        }
        if (player2Pos == m_player2.transform.position)
        {

            m_player2Control.GetComponent<Image>().CrossFadeAlpha(1, 0.5f, true);
        }
	}
}
