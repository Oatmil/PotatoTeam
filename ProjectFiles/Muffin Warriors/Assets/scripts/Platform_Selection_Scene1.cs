using UnityEngine;
using System.Collections;

public class Platform_Selection_Scene1 : MonoBehaviour
{
    public bool PlayerReady1 = false;
    public bool PlayerReady2 = false;

    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D col)
    {
        player1Controler PlayerController = col.transform.root.GetComponent<player1Controler>();
        if(PlayerController.PlayerNumber == 1)
        {
            PlayerReady1 = true;
        }
        if(PlayerController.PlayerNumber == 2)
        {
            PlayerReady2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player1Controler PlayerController = col.transform.root.GetComponent<player1Controler>();
        if (PlayerController.PlayerNumber == 1)
        {
            PlayerReady1 = false;
        }
        if (PlayerController.PlayerNumber == 2)
        {
            PlayerReady2 = false;
        }
    }
}
