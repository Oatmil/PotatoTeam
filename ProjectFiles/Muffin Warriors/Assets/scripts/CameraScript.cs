﻿using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {


	public float heightAdjusment;
	public float depthAdjustment;
	public float minimumDepth;

	public bool Begin;
	public Vector3[] m_CameraPoints;
	public int m_SetPoint;
	GameObject[] players = new GameObject[2];
	Vector3[] TarPosition = new Vector3[2];
	float Distance;
	Vector3 MidPoint;

    bool m_SlamSlow = false;
	public bool ScreenSlowMo = false;
	public float m_SlowMoTime;
	public float m_TimeScale; /// how slow;
	float slowMotime;
	AudioSource bgm;

	public bool ScreenShake = false;
	public float m_ScreenShakeTimer;
	float shaketime;
	Vector3 Pos;

	GameObject manager;
	GameObject UICanvas;

	void Start () {
		bgm = GameObject.FindGameObjectWithTag("Sounds").GetComponent<AudioSource>();
		players = GameObject.FindGameObjectsWithTag ("Player");
		manager = GameObject.FindGameObjectWithTag("Manager");
		UICanvas = GameObject.FindGameObjectWithTag("UICanvas");
		UICanvas.SetActive(false);
		manager.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Begin == true)
		{
			for (int i = 0; i < players.Length; i++)
			{
				TarPosition[i] = players[i].transform.position;
			}
			Distance = Vector2.Distance(TarPosition[0], TarPosition[1]);
			if (-Distance > minimumDepth)
			{
				MidPoint = new Vector3((TarPosition[0].x + TarPosition[1].x) / 2, heightAdjusment + (TarPosition[0].y + TarPosition[1].y) / 2, minimumDepth + depthAdjustment);
			}
			else
			{
				MidPoint = new Vector3((TarPosition[0].x + TarPosition[1].x) / 2, heightAdjusment + (TarPosition[0].y + TarPosition[1].y) / 2, -Distance);
			}
			transform.position = Vector3.Lerp(transform.position, MidPoint, 0.05f);
		}

		CameraShake();
		CameraSlowMo();
		SlowSound();
	}

	public void CameraShake()
	{
		if (ScreenShake == false)
		{
			Pos = transform.position;
		}
		if (ScreenShake == true)
		{
			Vector2 tempPos = Random.insideUnitCircle;
			transform.position = new Vector3(Mathf.Clamp(Pos.x + tempPos.x, Pos.x - 1.0f, Pos.x + 1.0f),
				Mathf.Clamp(Pos.y + tempPos.y, Pos.y - 1.0f, Pos.y + 1.0f),
				Pos.z);
			shaketime += Time.deltaTime;
		}
		if (shaketime > m_ScreenShakeTimer)
		{
			ScreenShake = false;
			shaketime = 0;
		}
	}

	public void CameraSlowMo()
	{
		if (ScreenSlowMo == true)
		{
			if (Time.timeScale == 1.0)
			{
				Time.timeScale = m_TimeScale;
				ScreenSlowMo = false;
			}
			else
			{
				Time.timeScale = 1.0f;
				Time.fixedDeltaTime = 0.02f * Time.timeScale;

				ScreenSlowMo = false;
			}
		}

		if (Time.timeScale == m_TimeScale)
		{
			slowMotime += Time.fixedDeltaTime;
		}

		if (slowMotime > m_SlowMoTime)
		{
			slowMotime = 0;
			Time.timeScale = 1.0f;
		}
	}

	public void SlowSound()
	{
		if (Time.timeScale == 1.0)
		{
			bgm.pitch = 1.0f;
		}
		else
		{
			bgm.pitch = 0.8f;
		}
	}

	public void GotoPosition()
	{
		transform.position = m_CameraPoints[m_SetPoint];
	}

	public void SetCameraPosition()
	{
		m_CameraPoints[m_SetPoint] = transform.position;
	}
}
