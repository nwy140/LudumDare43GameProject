using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float health=100f;
	
	//protect player 
	private bool isShielded;

	private Animator anim;

	private Image health_img;
	public bool isAlive = true;

	private Vector2 initialpos;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		health_img = GameObject.Find(TagManager.HP_ICON_HIERACHY).GetComponent<Image>();
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



}