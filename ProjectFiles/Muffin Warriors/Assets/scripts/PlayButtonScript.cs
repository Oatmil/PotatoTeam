using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour
{

    public static PlayButtonScript m_instance;

    public GameObject playbutton;
    public GameObject m_CanvasImage;
    public GameObject m_Credit;
    public GameObject m_GameMode;
    public bool b_Extreme;

    GameObject m_camera;
    CameraScript cameraScript;
    GameObject UICanvas;
    GameObject m_manager;
    Animator m_CanvasAnim;
    Animator m_CreditAnim;
    Animator m_GameModeAnim;

    bool m_controlOnOff = false;
    bool m_controlSwitch = false;
    bool m_Credits = false;
    bool b_PlayGame;

    void Awake()
    {
        m_instance = this;
    }

    void Start()
    {
        m_manager = GameObject.FindGameObjectWithTag("Manager");
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
        m_camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = m_camera.GetComponent<CameraScript>();
        m_CanvasAnim = m_CanvasImage.GetComponent<Animator>();
        m_CreditAnim = m_Credit.GetComponent<Animator>();
        m_GameModeAnim = m_GameMode.GetComponent<Animator>();
    }

    public void PlayGame()
    {
        cameraScript.Begin = true;
        UICanvas.SetActive(true);
        m_manager.SetActive(true);
        playbutton.SetActive(false);
    }

    public void PlayExtremeGame()
    {
        b_Extreme = true;
        cameraScript.Begin = true;
        UICanvas.SetActive(true);
        m_manager.SetActive(true);
        playbutton.SetActive(false);
    }


    public void ControlGame()
    {
        b_PlayGame = false;
        if (!m_controlOnOff)
        {
            m_controlOnOff = true;
            m_Credits = false;
            m_CanvasAnim.SetBool("ControlMasking", m_controlOnOff);
            m_CreditAnim.SetBool("CreditBool", m_Credits);
        }
        else
        {
            m_controlOnOff = false;
            m_CanvasAnim.SetBool("ControlMasking", m_controlOnOff);
        }
        m_GameModeAnim.SetBool("PlayGame", b_PlayGame);

    }
    public void ControlSwitch()
    {
        b_PlayGame = false;
        if (m_controlSwitch)
        {
            m_controlSwitch = false;
        }
        else
        {
            m_controlSwitch = true;
        }
        m_CanvasAnim.SetBool("ControlSwitch", m_controlSwitch);
        m_GameModeAnim.SetBool("PlayGame", b_PlayGame);
    }

    public void SelectGame()
    {
        b_PlayGame = true;
        m_GameModeAnim.SetBool("PlayGame", b_PlayGame);
    }

    public void Credits()
    {
        b_PlayGame = false;
        if (!m_Credits)
        {
            m_Credits = true;
            m_controlOnOff = false;
            m_CanvasAnim.SetBool("ControlMasking", m_controlOnOff);
            m_CreditAnim.SetBool("CreditBool", m_Credits);
        }
        else
        {
            m_Credits = false;
            m_CreditAnim.SetBool("CreditBool", m_Credits);
        }
        m_GameModeAnim.SetBool("PlayGame", b_PlayGame);
    }
}
