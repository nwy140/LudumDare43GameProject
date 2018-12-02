using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

	private WaveManager instance;
	public int bossperNumberofWaves  = 5;
	public int currentWave = 1;
	public int enemies_Left = 1;

	public bool loadingNextWave;

	GameObject[] enemies ;
	GameObject[] spawners ;
	


	// Use this for initialization
	void Awake () {
		MakeInstance();
	}
	
	void MakeInstance(){
		if(instance==null){
			instance = this;
		}
	}
	// Update is called once per frame
	void Update () {
		WaveClearCondition();

	}


	public void WaveClearCondition(){
		enemies = GameObject.FindGameObjectsWithTag(TagManager.ENEMY_TAG);	
		enemies_Left = enemies.Length;	
		spawners = GameObject.FindGameObjectsWithTag(TagManager.SPAWNER_TAG);		
		// All enemies dead
		if(enemies_Left<=0){
				StartCoroutine("LoadNextWave");
		}
	}

	public IEnumerator LoadNextWave() {
		
		//Loading Next Wave
			//disable all spawner and kill all enemy prefabs
		
		for(int i = 0 ; i<spawners.Length; i++){
			spawners[i].SetActive(false);
		}
	
		for(int i = 0 ; i<enemies.Length; i++){
			enemies[i].GetComponent<EnemyHealth>().TakeDamage(10000f); // instant kill
		}

		yield return new WaitForSeconds (3f);
		//Wave Loaded
		currentWave++;
		// reactivate spawner
		
		for(int i = 0 ; i<enemies.Length; i++){
			spawners[i].SetActive(true);
		}		

	
	}

}
