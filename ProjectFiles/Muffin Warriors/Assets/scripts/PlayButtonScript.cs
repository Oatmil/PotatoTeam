using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour
{

    public GameObject playbutton;
    public GameObject m_CanvasImage;
    public GameObject m_Credit;

    GameObject m_camera;
    CameraScript cameraScript;
    GameObject UICanvas;
    GameObject m_manager;
    Animator m_CanvasAnim;
    Animator m_CreditAnim;

    bool m_controlOnOff = false;
    bool m_controlSwitch = false;
    bool m_Credits = false;

    void Start()
    {
        m_manager = GameObject.FindGameObjectWithTag("Manager");
        UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
        m_camera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = m_camera.GetComponent<CameraScript>();
        m_CanvasAnim = m_CanvasImage.GetComponent<Animator>();
        m_CreditAnim = m_Credit.GetComponent<Animator>();
    }

    public void PlayGame()
    {
        cameraScript.Begin = true;
        UICanvas.SetActive(true);
        m_manager.SetActive(true);
        playbutton.SetActive(false);
    }

    public void ControlGame()
    {
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

    }
    public void ControlSwitch()
    {
        if (m_controlSwitch)
        {
            m_controlSwitch = false;
        }
        else
        {
            m_controlSwitch = true;
        }
        m_CanvasAnim.SetBool("ControlSwitch", m_controlSwitch);
    }

    public void Credits()
    {
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
        
    }
}
