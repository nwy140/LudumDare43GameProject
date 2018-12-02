using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningSpawner : MonoBehaviour {

	public float spawn_Left = -1f, spawn_Right = 1f;
	public float spawn_Limit = 5f;

	public GameObject spawnPrefab;
	private SpriteRenderer sr;

	private float pushForce = 0f;


	void Awake() {
		sr = GetComponent<SpriteRenderer> ();
	}

	void Start () {
//		RandomPosition ();

		InvokeRepeating ("SpawnObstacle", Random.Range(3, 5), 5);

	}

	void RandomPosition() {

		Vector3 temp = transform.position;

		if (Random.Range (0, 2) > 0) {

			temp.x = spawn_Left;
			sr.flipX = true;

		} else {

			temp.x = spawn_Right;

		}

	//	transform.position = temp;

	}

	void SpawnObstacle() {
		if(spawn_Limit>0){
			GameObject obstacle = Instantiate (spawnPrefab);

			Vector3 temp = transform.position;
			spawn_Limit--;
			if (transform.position.x > 0) {

				obstacle.transform.position = new Vector3 (temp.x + 5f,
					temp.y, 0f);

				// obstacle.GetComponent<Rigidbody2D> ().velocity = new Vector2 (
				// 	-pushForce, obstacle.GetComponent<Rigidbody2D> ().velocity.y);

			} else {

				obstacle.transform.position = new Vector3 (temp.x - 5f,
					temp.y, 0f);

				// obstacle.GetComponent<SpriteRenderer> ().flipX = true;

				// obstacle.GetComponent<Rigidbody2D> ().velocity = new Vector2 (
				// 	pushForce, obstacle.GetComponent<Rigidbody2D> ().velocity.y);
			
			}

			if (gameObject.activeInHierarchy) {
				StartCoroutine (TurnOffOnSign());
			}
		}

	}

	IEnumerator TurnOffOnSign() {
		yield return new WaitForSeconds (2f);
		sr.enabled = false;

		yield return new WaitForSeconds (1f);
		sr.enabled = true;
	}

} // class






























