using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float health=100f;
	
	//protect player 
	private bool isShielded;

	private Animator anim;
	private SpriteRenderer sr;

	private Image health_img;
	public bool isAlive = true;

	private Vector2 initialpos;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		health_img = GameObject.Find(TagManager.HP_ICON_HIERACHY).GetComponent<Image>();
		sr = GetComponent<SpriteRenderer>();
	}

	void Start(){
		initialpos = transform.position;
	}
	void Update(){
		//for debugging
		if(Input.GetKeyDown(KeyCode.K)){
			TakeDamage(20);

		} 
		
	
	}
	//getters and setters in C#
	public bool Shielded{
		get {return isShielded;}
		set {isShielded= value;}
	}

	public void TakeDamage(float amount){
		if(!isShielded ){
			health-=amount;
			health_img.fillAmount = health/100f;

			print("Player Took Damage, health is " + health);
			if (gameObject.activeInHierarchy && health>0) {
				StartCoroutine (TurnOffOnSign());
			}

			if(health<=0f){
				
				anim.Play (TagManager.DEAD_ANIMATION);
				GameplayController.instance.GameOver();
				//player dies
				//Destroy PLayer
				isAlive =false;

			}
		}
	}


	public void HealPlayer(float healAmount){
		health+= healAmount;
		health_img.fillAmount = health/100f;
		
		if(health>=100){
			health = 100f;
		}
	
	}


	IEnumerator TurnOffOnSign() {
		isShielded = true;
		for(int i =0; i<5; i++){
			yield return new WaitForSeconds (0.1f);
			sr.enabled = false;

			yield return new WaitForSeconds (0.1f);
			sr.enabled = true;
		}
		isShielded = false;
	}
	



}