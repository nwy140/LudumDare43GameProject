using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	private Rigidbody2D myBody;

	public bool autoChangeDirection = true;
	public bool goLeft =true;
	public float move_Speed = 2.8f;
	public float max_moveSpeed = 5f;
	public float jump_Force = 5f;
	public float damage = 20f; 
	public GameObject HitBox;
	public GameObject Shuriken;
	public bool meeleeAtk = true, rangeAtk = false, canJump = true;
	private Animator anim;
	private SpriteRenderer sr;

	private EnemyHealth enemyHealth ;



	// Use this for initialization
	void Awake () {
		sr = GetComponent<SpriteRenderer>();
		myBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		enemyHealth = GetComponent<EnemyHealth>();
		
	}
	void Start(){
		if(autoChangeDirection){

		InvokeRepeating ("ChangeDirection", Random.Range(3, 10), 5);
		InvokeRepeating ("Combat", Random.Range(2, 3), 3);
		InvokeRepeating ("Jump", Random.Range(10, 20), 3);

		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(myBody){
			Move();	
		}
		if(anim){
			AnimControl();
		}	
	}

	void Move() {
		if (goLeft) {
			myBody.velocity = new Vector2 (Mathf.Clamp(-move_Speed,-max_moveSpeed,max_moveSpeed), myBody.velocity.y);
			if(sr){
				sr.flipX = goLeft;
			} else{//for rouge
				transform.rotation = Quaternion.Euler(0, 180f, 0);
			}
		} else {
			myBody.velocity = new Vector2 (Mathf.Clamp( move_Speed,-max_moveSpeed,max_moveSpeed),myBody.velocity.y);
			if(sr){
				sr.flipX = goLeft;
			} else{// for rouge
				transform.rotation = Quaternion.Euler(0, 0f, 0);
			}	
		}

	}	
	void AnimControl(){
		//if moving, play walk anim
		if(myBody.velocity.x < -2 || myBody.velocity.x > 2   ){
			anim.SetBool (TagManager.WALK_BOOL_ANIMPARAM,true);
			// not holding key then only false
		} else {
			anim.SetBool (TagManager.WALK_BOOL_ANIMPARAM,false);

		}

		// // if falling or airborne , play anim		
		// if (myBody.velocity.y < -0.1 || myBody.velocity.y > 0.1  ){ 
		// 	anim.SetBool (TagManager.JUMP_BOOL_ANIMPARAM,true);   //fall
		// } else if((anim.GetCurrentAnimatorStateInfo(0).IsName(TagManager.JUMP_ANIMATION)) && (myBody.velocity.y ==0f)  ){
		// }

		//enable hitbox when attacking anim only
		if(anim.GetInteger(TagManager.Atk_ANIMATION) >0){
			HitBox.SetActive(true);
		} else{ // hide too fast, hitbox less likely to hit enemies
			
			HitBox.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		
		if (other.gameObject.tag == TagManager.BORDER_TAG  || other.gameObject.tag == TagManager.ENEMY_TAG ) {
			
			ChangeDirection();
		}	

	}

	 void OnTriggerEnter2D(Collider2D other) {
		// if fall out of map // instant kill 
		if(other.tag == TagManager.WORLDBOUNDARY_TAG){
			enemyHealth.TakeDamage(1000f);
		}		
	}

	void ChangeDirection(){
		goLeft = !goLeft;

	}
	void Combat(){
		if(anim && meeleeAtk){
			anim.SetInteger(TagManager.Atk_BOOL_ANIMPARAM,Random.Range(1,3));
			print(name + " tries to melee attack player ");
		} 

		if(anim&&rangeAtk){
			SoundManager.instance.PlayShurikenSound();
			

			anim.Play (TagManager.SKILL_ANIMATION);

			GameObject thrown = (GameObject)Instantiate (
			Shuriken,
			transform.position,
			transform.rotation);

			thrown.GetComponent<Projectile>().instigator = gameObject;
			thrown.GetComponent<Projectile>().move_Speed = 10f;				
			thrown.GetComponent<Projectile>().goLeft = goLeft;
			print(name + " tries to melee attack player ");

		}		
	}

	void Jump(){
		if(canJump){
			myBody.velocity += new Vector2 (0, jump_Force);
			SoundManager.instance.PlayJumpSound ();			
		}
		
	}
}
