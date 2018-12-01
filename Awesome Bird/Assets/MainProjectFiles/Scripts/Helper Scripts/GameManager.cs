using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	private GameData gameData;

	[HideInInspector]
	public int bestScore, diamondScore;

	[HideInInspector]
	public bool[] birds;

	[HideInInspector]
	public int selected_Index;

	void Awake() {
		MakeInstance ();

		InitializeGameData ();
	}

	void Start() {
//		print ("PATH: " + Application.persistentDataPath + TagManager.GAME_DATA);
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void InitializeGameData() {

		LoadGameData ();

		// if we havent saved game data before
		// save initial game data values
		if (gameData == null) {

			bestScore = 0;
			diamondScore = 1000;
			selected_Index = 0;

			birds = new bool[7];

			birds [0] = true;

			for (int i = 1; i < birds.Length; i++) {
				birds [i] = false;
			}

			gameData = new GameData ();

			gameData.BestScore = bestScore;
			gameData.DiamondScore = diamondScore;
			gameData.SelectedIndex = selected_Index;
			gameData.Birds = birds;

			SaveGameData ();
		}

	}

	public void SaveGameData() {
		FileStream file = null;

		try {
		
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Create(Application.persistentDataPath + TagManager.GAME_DATA);

			if(gameData != null) {

				gameData.BestScore = bestScore;
				gameData.DiamondScore = diamondScore;
				gameData.SelectedIndex = selected_Index;
				gameData.Birds = birds;

				bf.Serialize(file, gameData);
			}

		} catch(Exception e) {
			
		} finally {
			if (file != null) {
				file.Close();
			}
		}
	} // SAVE GAME DATA

	void LoadGameData() {
		FileStream file = null;

		try {
		
			BinaryFormatter bf = new BinaryFormatter();

			file = File.Open(Application.persistentDataPath + TagManager.GAME_DATA,
				FileMode.Open);

			gameData = (GameData)bf.Deserialize(file);

			if(gameData != null) {

				bestScore = gameData.BestScore;
				diamondScore = gameData.DiamondScore;
				selected_Index = gameData.SelectedIndex;
				birds = gameData.Birds;

			}

		} catch(Exception e) {
		
		} finally {
			if (file != null) {
				file.Close();
			}
		}

	} // Load Game Data

} // class















































