using UnityEngine;
using System.Collections;

public class ButtonAudio : MonoBehaviour {
	public AudioClip m_soundHover;
	AudioSource m_audio;

	void Start()
	{
		m_audio = GetComponent<AudioSource>();
	}

	public void OnMouseEnterButton()
	{
		m_audio.clip = m_soundHover;
		m_audio.Play();
	}

}
