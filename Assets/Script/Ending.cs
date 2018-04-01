using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

	GameObject computerPlane;
	GameObject computerCanvas;
	GameObject player;
	Transform playerTransform;
	Transform planeTransform;
	GameObject panel;
	Text[] b;
	bool isNear = false;
	bool isScreenOn = false;
	bool isCollected = false;
	public float timer;


	// Use this for initialization
	void Start () {
		computerPlane = GameObject.FindGameObjectWithTag ("Plane");
		computerCanvas = GameObject.FindGameObjectWithTag ("Canvas");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.transform;
		planeTransform = computerPlane.transform;

		updateCanvas (false);

	}

	// Update is called once per frame
	void Update () {
		isNearObject ();
		if (isNear && !isCollected) {
			if (!isScreenOn) {
				isScreenOn = true;
				updateCanvas (true);
				displayComputer ();
				timer = 0f;
			} else {
				if (timer > 2f && timer <= 4f) {
					b [0].text = "Collected Virus and Vaccine Data";
				} else if (timer > 4f) {
					jumpScense ();
					updateCanvas (false);
					isCollected = true;
				}
			}
			timer += Time.deltaTime;
		}

	}


	void jumpScense(){
		ChangeScene cs = new ChangeScene();
		cs.loadNextScene ();
	}

	void isNearObject(){
		float dist = Vector3.Distance (playerTransform.position, planeTransform.position);
		if (dist < 2.7f) {
			isNear = true;
		}
	}

	void displayComputer(){
		panel = GameObject.FindGameObjectWithTag ("Panel");
		b = panel.GetComponentsInChildren<Text> ();

	}

	void updateCanvas(bool active){
		foreach (Transform child in computerCanvas.transform)
		{
			child.gameObject.SetActive(active);
		}
	}

}
