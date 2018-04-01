﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

	public bool isRestart = false;
	// Use this for initialization
	void Start () {
		print ("testing");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Return"))
		{
			restart();
		}
		else if (Input.GetButtonDown("Submit"))
		{
			retry();
		}
	}


	void restart(){
		ChangeScence cs = new ChangeScence();
		cs.loadStartScence ();
	}

	void retry(){
		ChangeScence cs = new ChangeScence();
		cs.loadRetryScence ();

	}
}
