using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCharacter : MonoBehaviour {

	private Rigidbody2D myBody;

	public float move_Speed = 3.5f;
	private bool goLeft;

	private Animator anim;

	private SpriteRenderer sr;
	public float jump_Force = 5f, second_Jump_Force = 7f;
	

	private bool first_Jump, second_Jump = true;

	

	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
		
	}

	void Update () {

//		if (GameplayController.instance.playGame) {
			AnimControl();
			Move ();

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown(KeyCode.Space)) {
				JumpFunc ();
			}

//		}

	}

	void Move() {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			myBody.velocity += new Vector2 (-move_Speed, 0f);
			sr.flipX = true;
		} 
		else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			myBody.velocity += new Vector2 (+move_Speed, 0f);
			sr.flipX = false;
		
		} 
	}

	void JumpFunc() {
		
		if (first_Jump) {
		
			first_Jump = false;
			myBody.velocity += new Vector2 (0, jump_Force);


			SoundManager.instance.PlayJumpSound ();

		} else if (second_Jump) {
			
			second_Jump = false;
			myBody.velocity += new Vector2 (0, second_Jump_Force);


			SoundManager.instance.PlayJumpSound ();

		}

	}

	void AnimControl(){
		//if moving, play walk anim
		if(myBody.velocity.x < -0.1 || myBody.velocity.x > 0.1 ){
			anim.SetBool (TagManager.WALK_BOOL_ANIMPARAM,true);
		} else{
			anim.SetBool (TagManager.WALK_BOOL_ANIMPARAM,false);

		}

		// if falling or airborne , play anim		
		if (myBody.velocity.y < -0.1 || myBody.velocity.y > 0.1  ){ 
			anim.SetBool (TagManager.JUMP_BOOL_ANIMPARAM,true);
		}

	}

	void OnCollisionEnter2D(Collision2D target) {

		if (target.gameObject.tag == TagManager.GROUND_TAG) {
			if (myBody.velocity.y <= 1f) {
				first_Jump = true;
				second_Jump = true;			
				anim.SetBool (TagManager.JUMP_BOOL_ANIMPARAM,false);						
			}			

		}



	}

	void OnTriggerEnter2D(Collider2D target) {



	}
}
