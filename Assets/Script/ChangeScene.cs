using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour {

	string saveFilePath = Application.dataPath+ "/Data/Save.txt";
	// health , scence
	string scencesFilePath = Application.dataPath+ "/Data/SceneOrder.txt";

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

	private string getSceneName (int id){
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

	public int getCurrentSceneID(){
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

	public void loadPreviousScene (){
		int previous = getCurrentSceneID() - 1;
		if (previous < 0)
			previous = 0;
		
		writeSaveData (getPlayerHealth(), previous);
		SceneManager.LoadScene(getSceneName(previous));
	}
	public void loadNextScene (){
		int next = getCurrentSceneID() + 1;

		writeSaveData (getPlayerHealth(), next);
		SceneManager.LoadScene(getSceneName(next));
	}

	public void loadDeadScene (){
		writeSaveData (10, getCurrentSceneID());
		SceneManager.LoadScene("Dead");
	}

	public void loadStartScene (){
		writeSaveData (10, 0);
		SceneManager.LoadScene("Start");
	}

	public void loadRetryScene (){
		SceneManager.LoadScene(getSceneName(getCurrentSceneID()));
	}


}

