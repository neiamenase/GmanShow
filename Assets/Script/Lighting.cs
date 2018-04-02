using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lighting : MonoBehaviour {

	GameObject[] spotlights;
	public float timer;
	public float lightOnTime;
	public float lightOffTime;


	// Use this for initialization
	void Start () {
		spotlights = GameObject.FindGameObjectsWithTag("Light");
		string n = spotlights[0].name;
		timer = 0f;
		lightOnTime = 0.3f;
		lightOffTime = 1.5f;
		setColor ();
		lightEffect (false);

	}
	
	// Update is called once per frame
	void Update () {
		if (timer > lightOffTime && timer < lightOffTime + lightOnTime) {
			lightEffect (true);
		} else if (timer > lightOffTime + lightOnTime){
			lightEffect (false);
			timer = 0;
			lightOffTime = Random.value/4f;
			lightOnTime = Random.value;
		}

		timer += Time.deltaTime;

	}

	void lightEffect(bool turnOn){
		for (int i = 0; i < spotlights.Length; i++) {
			Light l = spotlights [i].GetComponent<Light> ();
			l.enabled = turnOn;
		}
	
	}

	void setColor(){
		for (int i = 0; i < spotlights.Length; i++) {
			Light l = spotlights [i].GetComponent<Light> ();
			l.color = new Color32(127,255,0,128);
		}

	}
}
