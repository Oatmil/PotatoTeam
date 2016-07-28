using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetButton : MonoBehaviour {

    public bool m_Pause = false;
    public GameObject m_PauseEndGameCanvas;
    public GameObject m_GameOverCanvas;
    public Text m_GameOverText;

    RoundManager m_manager;


    void Start()
    {
        //m_PauseEndGameCanvas.SetActive(false);
        m_manager = GetComponent<RoundManager>();
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
    public void GameOver(int totalDeath)
    {
        m_GameOverCanvas.SetActive(true);
        m_GameOverText.text = totalDeath.ToString();
    }

    public void Rematch()
    {
        m_manager.SetRematch();
        m_GameOverCanvas.SetActive(false);
    }
}
