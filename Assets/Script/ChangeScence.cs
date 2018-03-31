using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class ChangeScence : MonoBehaviour {

	string healthFilePath = Application.dataPath+ "/Data/Health.txt";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private int health = 30;
	public int Health{
	 get{
			
		StreamReader inp_stm = new StreamReader(healthFilePath);

		while(!inp_stm.EndOfStream)
		{
			return int.Parse(inp_stm.ReadLine( ));
			// Do Something with the input. 
		}

		inp_stm.Close( );  
		return health;

	}
		set{
			health = value;
		}
	}
}

