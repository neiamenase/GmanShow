using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoss : MonoBehaviour {

	Boss bossScript;
	GameObject boss;
	Text dialog;
	public int status;
	bool onPlane;

	void Start(){
		boss = GameObject.Find("Boss");
		bossScript = boss.GetComponent<Boss> ();
		dialog = GameObject.FindGameObjectWithTag ("Dialogue").GetComponentsInChildren<Text>()[0];
		status = 0;
		onPlane = false;
		
	}

	void Update(){
		if (onPlane && status == 0) {
			if (Input.GetButtonDown("Submit"))
			{
				bossScript.start = true;
				status = 1;
			}
		}
	}



	private void OnCollisionEnter(Collision collision) {
		print (collision.gameObject.name);
		if (collision.gameObject.tag == "Player"  ) {
			onPlane = true;
			switch (status) {
			case 0:
				dialog.text = "Press O to unseal ALL locks.";
				break;
			case 1:
				dialog.text = "Contamination found in room. Auto-lock applied";
				break;
			case 2:
				dialog.text = "Door unlocked";
				break;
			}
		}
	}

	private void OnCollisionExit(Collision collision){
		if (collision.gameObject.tag == "Player") {
			dialog.text = "";
			onPlane = false;
		}
	}
}
