﻿using UnityEngine;
using System.Collections;

public class PressToSpawn : MonoBehaviour 
{
	gotoStartGame gameFlag;
	public GameObject JesterToThis;
	PressToMove moveScript;
	StartGameOnTouch StartScript;
	RotateController RC;
    GameSettings Setting;
	// Use this for initialization
	void Start () 
	{
		gameFlag=GameObject.Find ("Main Camera").GetComponent<gotoStartGame> ();
		moveScript=gameObject.GetComponent<PressToMove>();
		moveScript.enabled=false;
		StartScript = GameObject.Find("ui_btn_start").GetComponent<StartGameOnTouch>();
		RC = JesterToThis.GetComponent<RotateController> ();
        Setting = GameObject.Find("MatchManager").GetComponent<GameSettings>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (gameFlag.isSelectionStarted) 
		{
			RC.speed=0;
		}
		if(gameFlag.isGameStarted)
		{
			moveScript.enabled=true;
		}
	}
	void OnTouchStay()
	{
		if(gameFlag.isSelectionStarted&!gameFlag.isGameStarted)
		{
			if(!JesterToThis.activeSelf)
			{
				JesterToThis.SetActive(true);
				StartScript.JesterCounter++;
				StartScript.JesterNames[StartScript.JesterCounter-1]=JesterToThis.name;
			}
		}
	}
    void OnTouchUp()
    {

    }
}
