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

	SmartSpawn.SmartSpawnScript smartSpawnScript;	

	public float WaveScoreRequired = 40f;


	// Use this for initialization
	void Awake () {
		MakeInstance();
		
	}

	void Start(){
		smartSpawnScript = GameObject.FindGameObjectWithTag(TagManager.SPAWNER_TAG).GetComponent<SmartSpawn.SmartSpawnScript>();
	}
	
	void MakeInstance(){
		if(instance==null){
			instance = this;
		}
	}
	// Update is called once per frame
	void Update () {
	
		if( int.Parse(GameplayController.instance.scoreText.text) >= currentWave * WaveScoreRequired){
		//	WaveClearCondition();
		}
	

	}


	public void WaveClearCondition(){
		enemies = GameObject.FindGameObjectsWithTag(TagManager.ENEMY_TAG);	
		enemies_Left = enemies.Length;	
				
		// All enemies dead
		//if(enemies_Left<=0){
				StartCoroutine("LoadNextWave");
		//}
	}

	public IEnumerator LoadNextWave() {
		
		EndWave();
		yield return new WaitForSeconds (5f);
		//Wave Loaded
		currentWave++;
		print("Loading Next Wave" + currentWave);
		smartSpawnScript.enabled=true;
		// reactivate spawner
	//	smartSpawnScript.waveResetTime = ;

	
	}

	void EndWave(){
		//Loading Next Wave
			//disable all spawner and kill all enemy prefabs
		loadingNextWave=true;
		for(int i = 0 ; i<enemies.Length; i++){
			enemies[i].GetComponent<EnemyHealth>().TakeDamage(10000f); // instant kill
		}		
		smartSpawnScript.enabled = false; 
	}

}


// smart spawner logic
/*
	Wave 1 
	Continue to spawn enemies a few times 
	A particular score reached for wave 1
	Kill all enemies, stop wave
	Wave 2
	Change wave spawner prefabs
	enable wave
	Continue to spawn enemies a few times 
	A particular score reached for wave 1
	Kill all enemies, enable reset waves after time


 */