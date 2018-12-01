using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  //Drag in the Bullet Emitter from the Component Inspector.

        Rigidbody2D myBody;
        [HideInInspector]
        public bool goLeft;
        public float move_Speed = 30f;
        public float Damage = 20f;
        // Use this for initialization
        void Awake ()
        {
            myBody = GetComponent<Rigidbody2D>();
        }
       
        // Update is called once per frame
        void Update (){

            if(goLeft){
 			    myBody.velocity = new Vector2 (-move_Speed, myBody.velocity.y);
            } else{
                
 			    myBody.velocity = new Vector2 (+move_Speed, myBody.velocity.y);
            }

        }

        void OnTriggerEnter2D(Collider2D other) {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if(enemyHealth){
                enemyHealth.TakeDamage(20f);
                Destroy(gameObject);
            }

        }
}
