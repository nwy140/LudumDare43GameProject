using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour {


	public float health = 40f;
	public float death_spawnChance = 30;

	void Awake() {

	}

	public void TakeDamage(float amount){
		health -= amount;


		print("Enemy Took Damage, health is " + health);
		if(health<= 0 ){
			GameplayController.instance.DisplayScore(10,0);
			if(Random.RandomRange(1,100) > death_spawnChance){
				// % chance coin spawn
				//spawn coin
			} 
				


			Destroy(gameObject);
		}
	}



}