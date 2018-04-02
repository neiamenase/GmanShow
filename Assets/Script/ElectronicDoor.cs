using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectronicDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter(Collision collision) {
		print (collision.gameObject.name);
		if (collision.gameObject.name == "Player_2" ) {
			GameObject.FindGameObjectWithTag("Dialogue").GetComponentsInChildren<Text>()[0].text = "It is an electronic door. \nPlease restart power generator.";

		}
	}
}
