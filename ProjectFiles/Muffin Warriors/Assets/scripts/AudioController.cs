using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

    public AudioClip[] m_SoundEffects;

    public float[] VolumeIndex;
    AudioSource m_audio;

    void Awake()
    {
		m_audio = GetComponent<AudioSource>();
    }

    void IdleSound()
    {
		m_audio.clip = m_SoundEffects[0];
		m_audio.volume = VolumeIndex[0];
		m_audio.Play();
    }

    void DownSound()
    {
		m_audio.clip = m_SoundEffects[1];
		m_audio.volume = VolumeIndex[1];
		m_audio.Play();
    }

    void InAirSound()
    {
		m_audio.clip = m_SoundEffects[2];
		m_audio.volume = VolumeIndex[2];
		m_audio.Play();
    }
    void UpSound()
    {
		m_audio.clip = m_SoundEffects[3];
		m_audio.volume = VolumeIndex[3];
		m_audio.Play();
    }

    void DmgIdle()
    {
		m_audio.clip = m_SoundEffects[4];
		m_audio.volume = VolumeIndex[4];
		m_audio.Play();
    }
    void DmgDown()
    {
		m_audio.clip = m_SoundEffects[5];
		m_audio.volume = VolumeIndex[5];
		m_audio.Play();
    }
    void DmgInAir()
    {
		m_audio.clip = m_SoundEffects[6];
		m_audio.volume = VolumeIndex[6];
		m_audio.Play();
    }
    void DmgUpAtk()
    {
		m_audio.clip = m_SoundEffects[7];
		m_audio.volume = VolumeIndex[7];
		m_audio.Play();
    }

    void Elemtent8()
    {
		m_audio.clip = m_SoundEffects[8];
		m_audio.volume = VolumeIndex[8];
		m_audio.Play();
    }

    void Element9()
    {
		m_audio.clip = m_SoundEffects[9];
		m_audio.volume = VolumeIndex[9];
		m_audio.Play();
    }
}
