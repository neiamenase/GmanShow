using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		ChangeScence cs = new ChangeScence();
		int health = cs.Health;
		print (health);
		computerPlane = GameObject.FindGameObjectWithTag ("Plane");
		computerCanvas = GameObject.FindGameObjectWithTag ("Canvas");
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.transform;
		planeTransform = computerPlane.transform;

		updateCanvas (false);

=======
		
>>>>>>> 46e41d01e3bd738583a27a8b1bb8d5c9c47f2074
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
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
					updateCanvas (false);
					isCollected = true;
				}
			}
			timer += Time.deltaTime;
		}

	}


	void jumpScense(){
		SceneManager.LoadScene("Explosion");
=======
		
>>>>>>> 46e41d01e3bd738583a27a8b1bb8d5c9c47f2074
	}
}
