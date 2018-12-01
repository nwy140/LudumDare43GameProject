using UnityEngine;
using System.Collections;


public class LevelManager : MonoBehaviour {


#region Functions

	public void LoadLevel (string Name) {	
		Debug.Log ("Level Load requeted for : "+Name);
		Application.LoadLevel (Name); 	
		
}


	public void RequestQuit () {
		Debug.Log ("I want to quit");
		Application.Quit();

}
	public void LoadNextLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}


	
#endregion



}
