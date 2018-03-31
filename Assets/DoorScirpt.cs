using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScirpt : MonoBehaviour {

	GameObject left;
	GameObject right;
	public bool isOpen;
	public bool open;
	// Use this for initialization
	void Start () {
		left = GameObject.Find ("leftDoor");
		right = GameObject.Find ("rightDoor");
		isOpen = false;
		open = false;
	}

	// Update is called once per frame
	void Update () {
		if (isOpen) {
			float dist = ((3f / 60f) * Time.deltaTime);
			left.transform.position = new Vector3 (left.transform.position.x + 1, left.transform.position.y, left.transform.position.z);
			right.transform.position = new Vector3 (right.transform.position.x - 1, right.transform.position.y, right.transform.position.z);
		}
		if (open) {
			left.transform.position = new Vector3 (left.transform.position.x + 10, left.transform.position.y, left.transform.position.z);
			right.transform.position = new Vector3 (right.transform.position.x - 10, right.transform.position.y, right.transform.position.z);
		}
		
	}
}
