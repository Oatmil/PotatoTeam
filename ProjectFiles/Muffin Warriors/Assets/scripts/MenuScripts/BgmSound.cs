using UnityEngine;
using System.Collections;

public class BgmSound : MonoBehaviour {
    AudioSource m_audio;
    bool muted = false;

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
}
