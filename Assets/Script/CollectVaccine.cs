using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectVaccine : MonoBehaviour {

	GameObject canvas;
	GameObject panel;
	Text[] b;
	bool isScreenOn = false;
	public float timer;


	// Use this for initialization
	void Start () {
		canvas = GameObject.FindGameObjectWithTag ("Canvas");
		updateCanvas (false);
		timer = 0f;

	}

	// Update is called once per frame
	void Update () {
		if (isScreenOn) {
			if (timer > 2f && timer <= 4f) {
				b [0].text = "Collected Virus and Vaccine Data";
			} else if (timer > 4f) {
				updateCanvas (false);
				isScreenOn = false;
			}
			timer += Time.deltaTime;
		}
	}


	void jumpScense(){
		ChangeScene cs = new ChangeScene();
		cs.loadNextScene ();
	}


	void displayComputer(){
		panel = GameObject.FindGameObjectWithTag ("Panel");
		b = panel.GetComponentsInChildren<Text> ();

	}

	void updateCanvas(bool active){
		foreach (Transform child in canvas.transform)
		{
			child.gameObject.SetActive(active);
		}
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player_2") {
			isScreenOn = true;
			updateCanvas (true);
			displayComputer ();
		}

	}

}
