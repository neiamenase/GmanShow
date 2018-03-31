using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

	Light myLight;
	public float minWaitTime;
	public float maxWaitTime;
	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light> ();
	}

	IEnumerator Flashing(){
		while(true){
			yield return new WaitForSeconds (Random.Range(minWaitTime
				, maxWaitTime));
			myLight.enabled = !myLight.enabled;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
