using UnityEngine;
using System.Collections;

public class BLockBarScript : MonoBehaviour {

    player1Controler playerScript;
    public int m_PlayState;
    public GameObject[] blockBars;

    void Awake()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<player1Controler>().PlayerNumber == m_PlayState)
            {
                playerScript = players[i].GetComponent<player1Controler>();
            }
        }
    }

    void Update()
    {
        if (playerScript.blockCharge == 0)
        {
            blockBars[0].SetActive(false);
            blockBars[1].SetActive(false);
            blockBars[2].SetActive(false);
        }
        else if (playerScript.blockCharge == 1)
        {
            blockBars[0].SetActive(true);
            blockBars[1].SetActive(false);
            blockBars[2].SetActive(false);
        }
        else if (playerScript.blockCharge == 2)
        {
            blockBars[0].SetActive(true);
            blockBars[1].SetActive(true);
            blockBars[2].SetActive(false);
        }
        else if (playerScript.blockCharge == 3)
        {
            blockBars[0].SetActive(true);
            blockBars[1].SetActive(true);
            blockBars[2].SetActive(true);
        }
    }
}
