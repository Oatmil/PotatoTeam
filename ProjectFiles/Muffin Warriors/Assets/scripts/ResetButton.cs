using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

    public bool m_Pause = false;
    public GameObject m_PauseEndGameCanvas;

    void Start()
    {
        //m_PauseEndGameCanvas.SetActive(false);
    }

    public void ChangeScene()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        if (m_Pause)
        {
            Time.timeScale = 1;
            m_Pause = false;
            m_PauseEndGameCanvas.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            m_Pause = true;
            m_PauseEndGameCanvas.SetActive(true);
        }
    }
}
