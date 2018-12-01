using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	private Rigidbody2D myBody;

	public bool autoChangeDirection = true;
	public bool goLeft =true;
	public float move_Speed = 2.8f;
	public float max_moveSpeed = 5f;

	public float Damage = 20f; 

	private SpriteRenderer sr;
	
	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer>();
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start(){
		if(autoChangeDirection){

		InvokeRepeating ("ChangeDirection", Random.Range(3, 10), 5);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move();	
		
	}

	void Move() {
		if (goLeft) {
			myBody.velocity = new Vector2 (Mathf.Clamp(-move_Speed,-max_moveSpeed,max_moveSpeed), myBody.velocity.y);
			sr.flipX = goLeft;
		} else {
			myBody.velocity = new Vector2 (Mathf.Clamp( move_Speed,-max_moveSpeed,max_moveSpeed),myBody.velocity.y);
			sr.flipX = goLeft;
		}

	}	

	void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.tag == TagManager.BORDER_TAG  || other.gameObject.tag == TagManager.ENEMY_TAG ) {
			
			ChangeDirection();
		}	

	}

	void ChangeDirection(){
		goLeft = !goLeft;

	}
}
