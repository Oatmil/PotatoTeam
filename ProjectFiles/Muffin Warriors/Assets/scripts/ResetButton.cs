using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResetButton : MonoBehaviour {

    public bool m_Pause = false;
    public GameObject m_PauseEndGameCanvas;
    public GameObject m_GameOverCanvas;
    public Text m_Player1DeathTEXT;
    public Text m_Player2DeathTEXT;
    RoundManager m_manager;
    public Image m_WinnerIcon;

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
    public void P1DeathTxt(int totalDeath)
    {
        m_GameOverCanvas.SetActive(true);
        m_Player1DeathTEXT.text = totalDeath.ToString();
    }

    public void P2DeathText(int totalDeath)
    {
        m_GameOverCanvas.SetActive(true);
        m_Player2DeathTEXT.text = totalDeath.ToString();
    }

    public void Rematch()
    {
        m_manager.SetRematch();
        m_GameOverCanvas.SetActive(false);
    }

    public void WinnerIcon(int i_index)
    {
        if (i_index == 1)
        {
            m_WinnerIcon.transform.position = new Vector3(m_Player1DeathTEXT.transform.position.x - 170, 
                                                            m_Player1DeathTEXT.transform.position.y + 30
                                                            , 0);
        }
        else if (i_index == 2)
        {
            m_WinnerIcon.transform.position = new Vector3(m_Player2DeathTEXT.transform.position.x + 170,
                                                            m_Player2DeathTEXT.transform.position.y + 30, 0);
        }
    }
}
