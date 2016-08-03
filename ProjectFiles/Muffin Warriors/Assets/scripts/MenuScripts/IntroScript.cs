using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

    public GameObject m_BGM;
    AudioSource m_BGMAudio;
    AudioSource m_introAudio;
    Animator anim;
    
    static bool doonce = false;

    void Awake()
    {
        anim = GetComponent<Animator>();
        m_introAudio = GetComponent<AudioSource>();
    }

    void Start()
    {
        m_BGMAudio = m_BGM.GetComponent<AudioSource>();
        m_BGMAudio.enabled = false;
        if (doonce == true)
        {
            anim.enabled = false;
            m_introAudio.enabled = false;
            m_BGMAudio.enabled = true;
        }
    }

    public void TurnOnBGM()
    {
        m_BGMAudio.enabled = true;
        doonce = true;
    }
}
