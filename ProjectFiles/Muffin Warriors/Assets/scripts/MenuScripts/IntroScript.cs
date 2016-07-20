using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

    public GameObject m_BGM;
    AudioSource m_BGMAudio;

    void Start()
    {
        m_BGMAudio = m_BGM.GetComponent<AudioSource>();
        m_BGMAudio.enabled = false;
    }

    public void TurnOnBGM()
    {
        m_BGMAudio.enabled = true;
    }
}
