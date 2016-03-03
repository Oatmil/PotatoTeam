using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioClip[] m_SoundEffects;

    public float Volume1;
    AudioSource sounds;
    void Awake()
    {
        sounds = GetComponent<AudioSource>();
    }

    void IdleSound()
    {
        sounds.clip = m_SoundEffects[0];
        sounds.Play();
    }

    void DownSound()
    {
        sounds.clip = m_SoundEffects[1];
        sounds.Play();
    }

    void InAirSound()
    {
        sounds.clip = m_SoundEffects[2];
        sounds.Play();
    }
    void UpSound()
    {
        sounds.clip = m_SoundEffects[3];
        sounds.Play();
    }

    void DmgIdle()
    {
        sounds.clip = m_SoundEffects[4];
        sounds.Play();
    }
    void DmgDown()
    {
        sounds.clip = m_SoundEffects[5];
        sounds.Play();
    }
    void DmgInAir()
    {
        sounds.clip = m_SoundEffects[6];
        sounds.Play();
    }
    void DmgUpAtk()
    {
        sounds.clip = m_SoundEffects[7];
        sounds.Play();
    }
}
