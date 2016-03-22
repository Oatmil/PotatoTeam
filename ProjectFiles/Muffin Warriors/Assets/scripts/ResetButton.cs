using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

    public void ChangeScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
