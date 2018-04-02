using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightingEffect : MonoBehaviour {

	GameObject[] spotlights;
	public float timer;
	public float lightOnTime;
	public float lightOffTime;
	public int restartGenerator = 0;
	private bool onPlane = false;



	// Use this for initialization
	void Start () {
		spotlights = GameObject.FindGameObjectsWithTag("Light");
		string n = spotlights[0].name;
		timer = 0f;
		lightOnTime = 0.3f;
		lightOffTime = 1.5f;

		lightEffect (false);

	}
	
	// Update is called once per frame
	void Update () {

		if (onPlane) {
			if (Input.GetButtonDown("Submit"))
			{
				restartGenerator = 1;
				GameObject.FindGameObjectWithTag("Dialogue").GetComponentsInChildren<Text>()[0].text = "";

			}
		}


		if (restartGenerator == 0) {
			if (timer > lightOffTime && timer < lightOffTime + lightOnTime) {
				lightEffect (true);
			} else if (timer > lightOffTime + lightOnTime) {
				lightEffect (false);
				timer = 0;
				lightOnTime = Random.value / 4f;
				lightOffTime = Random.value + 1f;
			}

			timer += Time.deltaTime;
		} else if (restartGenerator == 1){
			lightEffect (true);
			setDirectionalLight ();
			GameObject.Find ("electronicDoor").SetActive (false);
			restartGenerator = 2;
		}

	}

	void lightEffect(bool turnOn){
		for (int i = 0; i < spotlights.Length; i++) {
			Light l = spotlights [i].GetComponent<Light> ();
			l.enabled = turnOn;
		}
	
	}

	void setDirectionalLight(){
		for (int i = 0; i < spotlights.Length; i++) {
			Light l = spotlights [i].GetComponent<Light> ();
			l.type = LightType.Directional;
			l.intensity = 0.5f;
		}

	}


	// Update is called once per frame

	private void OnCollisionEnter(Collision collision) {
		print (collision.gameObject.name);
		if (collision.gameObject.name == "Player_2" ) {
			onPlane = true;
			GameObject.FindGameObjectWithTag("Dialogue").GetComponentsInChildren<Text>()[0].text = "Press O to restart power generator.";

		}
	}
	private void OnCollisionExit(Collision collision){
		if (collision.gameObject.name == "Player_2") {
			onPlane = false;
			GameObject.FindGameObjectWithTag ("Dialogue").GetComponentsInChildren<Text> () [0].text = "";
		}
	}
}
