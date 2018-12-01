using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	Rigidbody2D myBody;
	[HideInInspector]
	public bool goLeft ;
	public float move_Speed = 5f;
	public float Damage = 20f;

	private SpriteRenderer sr;
	
	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		Move();	
	}

	void Move() {
		if (goLeft) {
			myBody.velocity = new Vector2 (-move_Speed, myBody.velocity.y);
		} else {
			myBody.velocity = new Vector2 (move_Speed, myBody.velocity.y);
		}
	}	

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == TagManager.BORDER_TAG) {
			
			goLeft = !goLeft;
			sr.flipX = goLeft;

		}			
	}
}
