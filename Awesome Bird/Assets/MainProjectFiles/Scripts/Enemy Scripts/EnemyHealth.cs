using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour {


	public float health = 40f;
	public float death_spawnChance = 30;

	public Sprite death_Sprite;

	private SpriteRenderer sr;

	void Awake() {
		sr = GetComponent<SpriteRenderer>();

	}

	public void TakeDamage(float amount){
		health -= amount;


		if (gameObject.activeInHierarchy && health>0) {
			StartCoroutine (TurnOffOnSign());
		}
		print("Enemy Took Damage, health is " + health);
		
		if(health<= 0 ){
			GameplayController.instance.DisplayScore(10,0);
			if(Random.RandomRange(1,100) > death_spawnChance){
				// % chance coin spawn
				//spawn coin
			} 
				

			sr.sprite = death_Sprite;
			Destroy(gameObject , 0.3f);
		}
	}

	IEnumerator TurnOffOnSign() {

		for(int i =0; i<5; i++){
			yield return new WaitForSeconds (0.1f);
			sr.enabled = false;

			yield return new WaitForSeconds (0.1f);
			sr.enabled = true;
		}
	}	



}