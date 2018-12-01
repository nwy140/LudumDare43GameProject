using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

	private Rigidbody2D myBody;

	private SpriteRenderer sr;
	private float move_Speed = 3.5f;
	private bool goLeft;

	private Animator anim;

	private float jump_Force = 5f, second_Jump_Force = 7f;
	private bool first_Jump, second_Jump;

	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
		
	}

	void Update () {

		if (GameplayController.instance.playGame) {

			Move ();

			if (Input.GetMouseButtonDown (0)) {
				JumpFunc ();
			}

		}

	}

	void Move() {
		if (goLeft) {
			myBody.velocity = new Vector2 (-move_Speed, myBody.velocity.y);
		} else {
			myBody.velocity = new Vector2 (move_Speed, myBody.velocity.y);
		}
	}

	void JumpFunc() {
		if (first_Jump) {
		
			first_Jump = false;
			myBody.velocity = new Vector2 (myBody.velocity.x, jump_Force);

			anim.SetTrigger (TagManager.FLY_TRIGGER);

			SoundManager.instance.PlayJumpSound ();

		} else if (second_Jump) {
			
			second_Jump = false;
			myBody.velocity = new Vector2 (myBody.velocity.x, second_Jump_Force);

			anim.SetTrigger (TagManager.FLY_TRIGGER);

			SoundManager.instance.PlayJumpSound ();

		}
	}

	void OnCollisionEnter2D(Collision2D target) {

		if (target.gameObject.tag == TagManager.BORDER_TAG) {
			
			goLeft = !goLeft;
			sr.flipX = goLeft;

		}

		if (target.gameObject.tag == TagManager.GROUND_TAG) {

			if (myBody.velocity.y <= 1f) {
				first_Jump = true;
				second_Jump = true;
			}

		}

		if (target.gameObject.tag == TagManager.DOG_TAG) {

			GameplayController.instance.GameOver ();

			myBody.velocity = new Vector2 (0f, 0f);
			anim.Play (TagManager.DEAD_ANIMATION);

			Spawner.instance.CancelWarningSpawner ();

		}

	}

	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == TagManager.SCORE_TAG) {
			
			GameplayController.instance.DisplayScore (1, 0);

			target.gameObject.SetActive (false);
		}

		if (target.tag == TagManager.DIAMOND_TAG) {

			GameplayController.instance.DisplayScore (0, 1);

			target.gameObject.SetActive (false);

			SoundManager.instance.PlayDiamondSound ();

		}

	}

} // class










































