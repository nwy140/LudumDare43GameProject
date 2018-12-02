using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

	[HideInInspector]
    public GameObject instigator  ;

	public float damage = 30f;
	public float hitBoxOffsetByX = 1.04f;
	
	void Awake(){
			instigator = transform.parent.gameObject;
	}
	void Start () {
		
	}
	
	// Update is called once per frame	
	void Update () {
		if(transform.parent.GetComponent<SpriteRenderer>()){
			AdjustOffset();
		}
	}

	void AdjustOffset() {
		
		//hit left
		if(transform.parent.GetComponent<SpriteRenderer>().flipX == true ){
			
			transform.localPosition = new Vector2(  -hitBoxOffsetByX   , -0.3f);
		//hit right
		} else if((transform.parent.GetComponent<SpriteRenderer>().flipX == false )){
			transform.localPosition = new Vector2( +hitBoxOffsetByX , -0.3f);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {	
		GameObject tempObj = transform.parent.gameObject;
		// protect null ptr // attack enemy as player
		if(other.gameObject.tag == TagManager.ENEMY_TAG && instigator.tag == TagManager.PLAYER_TAG ){
			SoundManager.instance.hitSoundManager.Play();
			other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
		}
	
		// protect null ptr // attack player as enemy
		if(other.gameObject.tag == TagManager.PLAYER_TAG && instigator.tag == TagManager.ENEMY_TAG ){
			SoundManager.instance.hitSoundManager.Play();
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
	}
}
