using UnityEngine;
using System.Collections;

public class BgmSound : MonoBehaviour {
    AudioSource m_audio;
    bool muted = false;

    public AudioClip m_Env1;
    public AudioClip m_Env2;
    public AudioClip m_Env3;
    public AudioClip m_Env4;
    public AudioClip m_Env5;


    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        
    }

    public void Mute()
    {
        if (muted == true)
        {
            muted = false;
            m_audio.volume = 1;
        }
        else
        {
            muted = true;
            m_audio.volume = 0;
        }
    }


    public void SetAudio(int soundNum)
    {
        if (soundNum == 0)
        {
            m_audio.clip = m_Env1;
            m_audio.Play();
        }
        if (soundNum == 1)
        {
            m_audio.clip = m_Env2;
            m_audio.Play();
        }
        if (soundNum == 2)
        {
            m_audio.clip = m_Env3;
            m_audio.Play();
        }
        if (soundNum == 3)
        {
            m_audio.clip = m_Env4;
            m_audio.Play();
        } 
        if (soundNum == 4)
        {
            m_audio.clip = m_Env5;
            m_audio.Play();
        }
    }

}
