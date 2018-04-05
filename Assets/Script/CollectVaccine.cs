using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectVaccine : MonoBehaviour {


	int collectingStatus = 0;
	bool onPlane = false;
	float second;
	int loadingTime;

	Text dialogue;


	// Use this for initialization
	void Start () {
		dialogue = GameObject.FindGameObjectWithTag ("Dialogue").GetComponentsInChildren<Text> () [0];

	}

	// Update is called once per frame
	void Update () {
		if (onPlane) {
			if (collectingStatus == 0) {
				dialogue.text = "Loading... \nDon't move.\n";
				collectingStatus = 1;
				loadingTime = 5;
			} else if (collectingStatus == 1) {
				second += Time.deltaTime;
				if (second >=1) {
					if (loadingTime > 0) {
						dialogue.text += loadingTime + "... ";
					} else if (loadingTime == 0) {
						dialogue.text = "Collected Virus and Vaccine Data.";
					} else {
						dialogue.text = "end??";
						collectingStatus = 2;
					}
					second = 0;
					loadingTime--;
				}
			}
		}

	}


	void jumpScense(){
		ChangeScene cs = new ChangeScene();
		cs.loadNextScene ();
	}



	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			onPlane = true;
		}

	}
	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Player") {
			onPlane = false;
			if (collectingStatus != 2) {
				dialogue.text = "";
				collectingStatus = 0;
			}
		}

	}
}
