using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.SceneManagement;


public class ChangeScence : MonoBehaviour {

	string saveFilePath = Application.dataPath+ "/Data/Save.txt";
	// health , scence
	string scencesFilePath = Application.dataPath+ "/Data/ScencesOrder.txt";

	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}
//	private int health = 30;
//	public int Health{
//	 	get{
//			return health;
//		}
//		set{
//			health = value;
//		}
//	}

	public void writeSaveData(int health, int scenceID){
		StreamWriter writer = new StreamWriter (saveFilePath);
		writer.Write(health.ToString() + "," + scenceID.ToString());
		writer.Close ();

	}

	public string[] readSaveData(){
		StreamReader reader = new StreamReader(saveFilePath);
		string[] data = { "" };
		if(!reader.EndOfStream)
		{
			data = reader.ReadLine( ).Split(',');
		}
		reader.Close( ); 
		return data;
	}

	private string getScenceName (int id){
		int i = 0;
		StreamReader reader = new StreamReader(scencesFilePath);
		while(!reader.EndOfStream)
		{
			string scenceName = reader.ReadLine ();
			if (i == id) {
				print (i + "   " + scenceName);
				return scenceName;
			}
			i++;
		}
		reader.Close( );  
		return "Start";
	}

	public int getHealthData(){

		return int.Parse (readSaveData()[0]);
	}

	public int getCurrentScenceID(){
		return int.Parse (readSaveData()[1]);
	}

	public int getPlayerHealth(){
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null)
			return 10;
		PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
		if (playerHealth == null)
			return 10;
		return playerHealth.getCurrentHealth ();
	
	}

	public void loadPreviousScence (){
		int previous = getCurrentScenceID() - 1;
		if (previous < 0)
			previous = 0;
		
		writeSaveData (getPlayerHealth(), previous);
		SceneManager.LoadScene(getScenceName(previous));
	}
	public void loadNextScence (){
		int next = getCurrentScenceID() + 1;

		writeSaveData (getPlayerHealth(), next);
		SceneManager.LoadScene(getScenceName(next));
	}

	public void loadDeadScence (){
		writeSaveData (10, getCurrentScenceID());
		SceneManager.LoadScene("Dead");
	}

	public void loadStartScence (){
		writeSaveData (10, 0);
		SceneManager.LoadScene("Start");
	}

	public void loadRetryScence (){
		SceneManager.LoadScene(getScenceName(getCurrentScenceID()));
	}


}

