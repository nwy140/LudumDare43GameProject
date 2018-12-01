using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

	public float projectile_Speed = 10f;
	private Rigidbody2D myBody;

	[HideInInspector]
//	public GameObject instigator;

	// Use this for initialization
	void Awake () {
		myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		myBody.velocity += new Vector2(   transform.forward.x * projectile_Speed, 0f);


	}

	void OnTriggerEnter2D(Collider2D other) {
		//damage	
	}
}
