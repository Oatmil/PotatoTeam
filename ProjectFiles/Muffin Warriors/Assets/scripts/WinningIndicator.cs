using UnityEngine;
using System.Collections;

public class WinningIndicator : MonoBehaviour {

    GameObject manager;
    RoundManager managerScript;

    public int state;
    public GameObject[] cherries = new GameObject[2];

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("Manager");
        managerScript = manager.GetComponent<RoundManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (state == 1)
        {
            if (managerScript.Player1Score == 0)
            {
                cherries[0].SetActive(false);
                cherries[1].SetActive(false);
            }

            if (managerScript.Player1Score == 1)
            {
                cherries[0].SetActive(true);
            }
            if (managerScript.Player1Score == 2)
            {
                cherries[1].SetActive(true);
            }
        }
        if (state == 2)
        {
            if (managerScript.Player2Score == 0)
            {
                cherries[0].SetActive(false);
                cherries[1].SetActive(false);
            }

            if (managerScript.Player2Score == 1)
            {
                cherries[0].SetActive(true);
            }
            if (managerScript.Player2Score == 2)
            {
                cherries[1].SetActive(true);
            }
        }
	}
}
