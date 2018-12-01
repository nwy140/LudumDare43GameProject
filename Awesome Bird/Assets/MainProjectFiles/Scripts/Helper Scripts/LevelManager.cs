using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour {

	public static LevelManager instance;

	public void Awake() {
		MakeInstance();
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}	
	public void LoadLevel (string Name) {	
		Debug.Log ("Level Load requeted for : "+Name);
		Application.LoadLevel (Name); 	
		
	}
	
	public void RestartLevel () {	
		Debug.Log ("Level Load requeted for : "+ "Restart Level");
		Application.LoadLevel (SceneManager.GetActiveScene().name); 	
		
	}
	
	
	public void RequestQuit () {
		Debug.Log ("I want to quit");
		Application.Quit();

	}
	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}


	

}
