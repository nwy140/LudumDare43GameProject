using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
  //Drag in the Bullet Emitter from the Component Inspector.

        [HideInInspector]
        public GameObject instigator  ;
        Rigidbody2D myBody;
        [HideInInspector]
        public bool goLeft;
        public float move_Speed = 30f;
        public float damage = 20f;
        // Use this for initialization
        void Awake ()
        {
            myBody = GetComponent<Rigidbody2D>();
            Destroy(gameObject,3f); // lifespan
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
            if(other.gameObject.tag == TagManager.ENEMY_TAG && instigator.tag == TagManager.PLAYER_TAG ){
                SoundManager.instance.hitSoundManager.Play();
                other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }
        
            // protect null ptr // attack player as enemy
            if(other.gameObject.tag == TagManager.PLAYER_TAG && instigator.tag == TagManager.ENEMY_TAG ){
                SoundManager.instance.hitSoundManager.Play();
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                Destroy(gameObject);
            }

        }

        
}
