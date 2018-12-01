using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

	public float damage = 30f;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {	

		// protect null ptr
		if(other.gameObject.tag == TagManager.ENEMY_TAG){
			SoundManager.instance.hitSoundManager.Play();
			other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
		}
	
	}

	void OnCollisionEnter2D(Collision2D other) {
	}
}
