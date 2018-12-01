using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour {


	public float health = 40f;

	void Awake() {

	}

	public void TakeDamage(float amount){
		health -= amount;


		print("Enemy Took Damage, health is " + health);
		if(health<= 0 ){
			Destroy(gameObject,3f);
		}
	}



}