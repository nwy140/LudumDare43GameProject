using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	public Text scoreText, bestScoreText, cointScoreText, totalCoinScoreText;
	private int count_Score, count_Coin;

	public GameObject mainMenuObj, gameOverObj, birdMenuObj, UIObj;

	[HideInInspector]
	public bool playGame;

	public Text mainMenu_DisplayBestScoreText, birdMenu_DisplayBestScoreText,
		birdMenu_DisplayCoinScoreText;

	public GameObject[] birds;
	public GameObject[] bird_Price_Text;
	public GameObject[] bird_Icons;

	void Awake() {
		MakeInstance ();
	}

	void Start () {
		// mainMenu_DisplayBestScoreText.text = "Best: " + GameManager.instance.bestScore;

		// InstantiatePlayer ();
	}
	
	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	public void DisplayScore(int score, int coin) {
		count_Score += score;
		count_Coin += coin;

		scoreText.text = count_Score.ToString();
		cointScoreText.text = count_Coin.ToString ();
	}

	public void GameOver() {

		playGame = false;

		gameOverObj.SetActive (true);
		gameOverObj.GetComponent<Animator> ().Play (TagManager.FADE_IN_ANIMATION);

		// THIS WILL SAVE GAME DATA

		// int currentBestScore = GameManager.instance.bestScore;

		// if (currentBestScore < count_Score) {
		// 	GameManager.instance.bestScore = count_Score;
		// }

		// GameManager.instance.diamondScore += count_Diamond;

		// if (count_Score >= 25) {
		// 	GameManager.instance.birds [GameManager.instance.birds.Length - 1] = true;
		// }

		// GameManager.instance.SaveGameData ();

	}

	public void PlayGame() {

		// IF WE ARE NOT PLAYING THE GAME
		if (!playGame) {
		
			mainMenuObj.SetActive (false);
			UIObj.SetActive (true);

			playGame = true;

			bestScoreText.text = "Best: " + GameManager.instance.bestScore;
			totalCoinScoreText.text = "Total: " + GameManager.instance.coinScore;

		}

	}

/*
	public void RestartGame() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void MainMenu() {
		gameOverObj.SetActive (false);
		birdMenuObj.SetActive (false);
		mainMenuObj.SetActive (true);

		InstantiatePlayer ();
	}

	public void BirdMenu() {
		birdMenuObj.SetActive (true);
		mainMenuObj.SetActive (false);

		birdMenu_DisplayBestScoreText.text = "Best: " + GameManager.instance.bestScore;
		birdMenu_DisplayCoinScoreText.text = GameManager.instance.coinScore.ToString ();

		CheckBirds ();

	}

	void CheckBirds() {

		for (int i = 0; i < bird_Price_Text.Length; i++) {

			bird_Price_Text [i].SetActive (!GameManager.instance.birds[i + 1]);

			bird_Icons [i].SetActive (GameManager.instance.birds[i + 1]);

		}

	}

	public void UnlockAndSelectBird() {
		
		int selectedBirdIndex = int.Parse (
			UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

		// IF THE BIRD IS LOCKED
		if (!GameManager.instance.birds [selectedBirdIndex]) {

			switch (selectedBirdIndex) {
				
			case 1:

				if (GameManager.instance.coinScore >= 25) {
					GameManager.instance.birds [selectedBirdIndex] = true;
					GameManager.instance.coinScore -= 25;
					GameManager.instance.selected_Index = selectedBirdIndex;
				}

				break;

			case 2:
				if (GameManager.instance.coinScore >= 50) {
					GameManager.instance.birds [selectedBirdIndex] = true;
					GameManager.instance.coinScore -= 50;
					GameManager.instance.selected_Index = selectedBirdIndex;
				}
				break;

			case 3:
				if (GameManager.instance.coinScore >= 75) {
					GameManager.instance.birds [selectedBirdIndex] = true;
					GameManager.instance.coinScore -= 75;
					GameManager.instance.selected_Index = selectedBirdIndex;
				}
				break;

			case 4:
				if (GameManager.instance.coinScore >= 100) {
					GameManager.instance.birds [selectedBirdIndex] = true;
					GameManager.instance.coinScore -= 100;
					GameManager.instance.selected_Index = selectedBirdIndex;
				}
				break;

			case 5:
				if (GameManager.instance.coinScore >= 100) {
					GameManager.instance.birds [selectedBirdIndex] = true;
					GameManager.instance.coinScore -= 100;
					GameManager.instance.selected_Index = selectedBirdIndex;
				}
				break;

			}

		} else {

			GameManager.instance.selected_Index = selectedBirdIndex;

		}

		CheckBirds ();
		birdMenu_DisplayCoinScoreText.text = GameManager.instance.coinScore.ToString ();
		GameManager.instance.SaveGameData ();

	}

	void InstantiatePlayer() {
		GameObject player = GameObject.FindGameObjectWithTag (TagManager.PLAYER_TAG);
		Vector3 pos = player.transform.position;

		player.SetActive (false);

		Instantiate (birds[GameManager.instance.selected_Index], pos, Quaternion.identity);

		Camera.main.gameObject.GetComponent<CameraFollow> ().FindPlayer ();
	}
 */

} // class








































