using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioClip[] m_SoundEffects;

    public float[] VolumeIndex;
    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void IdleSound()
    {
        audio.clip = m_SoundEffects[0];
        audio.volume = VolumeIndex[0];
        audio.Play();
    }

    void DownSound()
    {
        audio.clip = m_SoundEffects[1];
        audio.volume = VolumeIndex[1];
        audio.Play();
    }

    void InAirSound()
    {
        audio.clip = m_SoundEffects[2];
        audio.volume = VolumeIndex[2];
        audio.Play();
    }
    void UpSound()
    {
        audio.clip = m_SoundEffects[3];
        audio.volume = VolumeIndex[3];
        audio.Play();
    }

    void DmgIdle()
    {
        audio.clip = m_SoundEffects[4];
        audio.volume = VolumeIndex[4];
        audio.Play();
    }
    void DmgDown()
    {
        audio.clip = m_SoundEffects[5];
        audio.volume = VolumeIndex[5];
        audio.Play();
    }
    void DmgInAir()
    {
        audio.clip = m_SoundEffects[6];
        audio.volume = VolumeIndex[6];
        audio.Play();
    }
    void DmgUpAtk()
    {
        audio.clip = m_SoundEffects[7];
        audio.volume = VolumeIndex[7];
        audio.Play();
    }

    void Elemtent8()
    {
        audio.clip = m_SoundEffects[8];
        audio.volume = VolumeIndex[8];
        audio.Play();
    }

    void Element9()
    {
        audio.clip = m_SoundEffects[9];
        audio.volume = VolumeIndex[9];
        audio.Play();
    }
}
