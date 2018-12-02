using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerCharacter : MonoBehaviour {

	private Rigidbody2D myBody;
	private Animator anim;
	private SpriteRenderer sr;
	private PlayerHealth playerHealth;
	
	// Character Stats

	public float move_Speed = 3f;
	public float max_moveSpeed = 20f;
	public float jump_Force = 5f, second_Jump_Force = 7f;
	public bool boost_Dash;
	public float boostSpeed = 6f;

	private bool first_Jump, second_Jump = true;
	private bool goLeft;


	public GameObject Shuriken;
	public GameObject HitBox;


	void Awake() {
		myBody = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();

		playerHealth = GetComponent<PlayerHealth>();
	}

	void Start () {
		
	}

	void Update () {

//		if (GameplayController.instance.playGame) {
			AnimControl();
			Move ();
			Combat();
			if (Input.GetKeyDown(KeyCode.Space)) {
				JumpFunc ();
			}

//		}

	}

	void Move() {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
			myBody.velocity =  new Vector2 (Mathf.Clamp(-move_Speed,-max_moveSpeed,+max_moveSpeed), myBody.velocity.y);
			goLeft = true;
			sr.flipX = goLeft;
			
		} 
		else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
			myBody.velocity =  new Vector2 (Mathf.Clamp(+move_Speed,-max_moveSpeed,+max_moveSpeed), myBody.velocity.y);			
			goLeft = false;
			sr.flipX = goLeft;
			
		} 

		
		// stop input by stopping script
		if(playerHealth.isAlive == false){
			GetComponent<SideScrollerCharacter>().enabled = false;
		}

		if ((first_Jump  && boost_Dash) &&  (Input.GetKeyDown(KeyCode.LeftShift) ||Input.GetMouseButton(2)) ) //middle mouse button
		{
    	   StartCoroutine( Boost(1.2f) ); //Start the Coroutine called "Boost", and feed it the time we want it to boost us
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

	void Combat(){
		if(Input.GetMouseButtonDown(0)){
			SoundManager.instance.PlayAtkSound();
			anim.Play(TagManager.Atk_ANIMATION);
			
		}

		if(Input.GetMouseButtonDown(1)){
			SoundManager.instance.PlayShurikenSound();
			

			anim.Play (TagManager.SKILL_ANIMATION);

			GameObject thrown = (GameObject)Instantiate (
			Shuriken,
			transform.position,
			transform.rotation);
			thrown.GetComponent<Projectile>().instigator = gameObject;
			
			thrown.GetComponent<Projectile>().goLeft = goLeft;

		}
	}

	void AnimControl(){
		//if moving, play walk anim
		if(myBody.velocity.x < -0.1 || myBody.velocity.x > 0.1  ){
			anim.SetBool (TagManager.WALK_BOOL_ANIMPARAM,true);
			// not holding key then only false
		} else if(!(   Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)  )  || !(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) ) {
			anim.SetBool (TagManager.WALK_BOOL_ANIMPARAM,false);

		}

		// if falling or airborne , play anim		
		if (myBody.velocity.y < -0.1 || myBody.velocity.y > 0.1  ){ 
			anim.SetBool (TagManager.JUMP_BOOL_ANIMPARAM,true);   //fall
		} else if((anim.GetCurrentAnimatorStateInfo(0).IsName(TagManager.JUMP_ANIMATION)) && (myBody.velocity.y ==0f)  ){
			ResetDoubleJump();
		}

		//enable hitbox when attacking anim only
		if(anim.GetCurrentAnimatorStateInfo(0).IsName(TagManager.Atk_ANIMATION) ){
			HitBox.SetActive(true);
		} else{ // hide too fast, hitbox less likely to hit enemies
			
			HitBox.SetActive(false);
		}
	}

	void ResetDoubleJump(){
			anim.SetBool (TagManager.JUMP_BOOL_ANIMPARAM,false);						

			if (myBody.velocity.y <= 1f) {
				first_Jump = true;
				second_Jump = true;			
			}				
	}
	void OnCollisionEnter2D(Collision2D target) {
		// Platform collision
		if (target.gameObject.tag == TagManager.GROUND_TAG || target.gameObject.tag == TagManager.ENEMY_TAG  ) {
			ResetDoubleJump();

		} 
		// Enemies Collision
			// reduce HP
		if (target.gameObject.tag == TagManager.ENEMY_TAG || target.gameObject.tag == TagManager.OBSTACLE_TAG) {
			EnemyPatrol enemyPatrol = target.gameObject.GetComponent<EnemyPatrol>();

			if(enemyPatrol){
				playerHealth.TakeDamage(enemyPatrol.damage);
			} else{
				playerHealth.TakeDamage(20f);
			}

		}

				//if reach finishline
		if(target.gameObject.tag == TagManager.FINISHLINE){
			;
			LevelManager.instance.LoadNextLevel();
		}		


	}



	void OnTriggerEnter2D(Collider2D target) {

		if (target.tag == TagManager.SCORE_TAG) {
			
			GameplayController.instance.DisplayScore (1, 0);

			target.gameObject.SetActive (false);
		}

		if (target.tag == TagManager.COIN_TAG) {

			GameplayController.instance.DisplayScore (0, 1);

			target.gameObject.SetActive (false);

			SoundManager.instance.PlayDiamondSound ();

		}
		if (target.tag == TagManager.POTION_TAG) {

			GameplayController.instance.DisplayScore (1, 0); //potion point

			target.gameObject.SetActive (false);

			SoundManager.instance.PlayPotionSound ();
			playerHealth.HealPlayer(40f);


		}

		// if fall out of map // instant kill 
		if(target.tag == TagManager.WORLDBOUNDARY_TAG){
			playerHealth.TakeDamage(1000f);
		}

	}

    IEnumerator Boost(float boostDur) //Coroutine with a single input of a float called boostDur, which we can feed a number when calling
    {
		print("Player dash");	
        float time = 0; //create float to store the time this coroutine is operating
        boost_Dash = false; //set canBoost to false so that we can't keep boosting while boosting
 
        while(boostDur > time) //we call this loop every frame while our custom boostDuration is a higher value than the "time" variable in this coroutine
        {
            time += Time.deltaTime; //Increase our "time" variable by the amount of time that it has been since the last update
            if(goLeft){
			myBody.velocity = new Vector2(-boostSpeed, myBody.velocity.y); //set our rigidbody velocity to a custom velocity every frame, so that we get a steady boost direction like in Megaman
			}
            else{
				myBody.velocity = new Vector2(+boostSpeed, myBody.velocity.y); //set our rigidbody velocity to a custom velocity every frame, so that we get a steady boost direction like in Megaman		
			}
			yield return 0; //go to next frame
        }
         yield return new WaitForSeconds(3f); //Cooldown time for being able to boost again, if you'd like.
         boost_Dash = true; //set back to true so that we can boost again.
    } //from https://forum.unity.com/threads/2d-platformer-mega-man-x-style-dash.228648/
	
}
