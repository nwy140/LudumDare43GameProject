using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public static Spawner instance;

	public GameObject ground_Prefab;

	private float ground_Y_Distance = 3.3f;

	private float current_Y_Position = 0f;

	public GameObject[] dogs;
	private float xPos = 2.55f;

	public GameObject[] collectables;

	void Awake() {
		MakeInstance ();
	}

	void Start () {
		SpawnInitialGrounds ();
	}
	
	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void SpawnInitialGrounds() {

		for (int i = 0; i < 5; i++) {
			SpawnMoreGrounds ();
		}

	}

	public void SpawnMoreGrounds() {
		
		current_Y_Position += ground_Y_Distance;

		GameObject newGround = Instantiate (ground_Prefab);

		newGround.transform.position = new Vector3 (0f, current_Y_Position, 0f);


		// SPAWN OBSTACLES
		int randomForDogs = Random.Range (0, 10);

		if (randomForDogs > 1) {

			GameObject obstacle = Instantiate (dogs[Random.Range(0, dogs.Length)]);

			if (obstacle.tag == TagManager.WARNING_TAG) {

				obstacle.transform.position = new Vector2 (0f,
					newGround.transform.position.y + 0.8f);

			} else {

				obstacle.transform.position = new Vector2 (Random.Range(-xPos, xPos),
					newGround.transform.position.y + 0.5f);
			
			}

		}

		SpawnCollectables ();

	}

	void SpawnCollectables() {

		if (Random.Range (0, 2) == 1) {

			GameObject collectableItem = Instantiate (collectables[Random.Range(0, collectables.Length)]);

			collectableItem.transform.position = new Vector2 (Random.Range(-xPos, xPos),
				current_Y_Position + 0.5f);

		}

	}

	public void CancelWarningSpawner() {
		GameObject[] warnings = GameObject.FindGameObjectsWithTag (TagManager.WARNING_TAG);

		for (int i = 0; i < warnings.Length; i++) {
			warnings [i].GetComponent<WarningSpawner> ().CancelInvoke ();
		}

	}

} // class
















































