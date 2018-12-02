using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameobject : MonoBehaviour {
	public bool deactivate_when_tooFar = true;
	public bool activate_when_Near = true;
	//Gameobj should only be Active between distance
	public float distanceActivebyX = 35f ; 
	
	private Rigidbody2D myBody;
	private GameObject tempParent;

	
	void Awake(){
		myBody = GetComponent<Rigidbody2D>();
	}
	void Start(){
		if(transform.parent.gameObject){
			tempParent = transform.parent.gameObject;
		}		
	}

	void Update () {
		ManageLOD();
	}

	public void DeactivateGameObjMovement() {
		//toofar
			//disable movement
		if(myBody){
  			myBody.constraints = RigidbodyConstraints2D.FreezeAll;
			print("deactivate obj : " + gameObject.name);
		} else{
			//Get all scripts
		}			
	}
	public void ActivateGameObjMovement() {
		//near
			//enable movement
		if(myBody){
            myBody.constraints = RigidbodyConstraints2D.None;
			myBody.constraints = RigidbodyConstraints2D.FreezeRotation;
			print("activate obj : " + gameObject.name);
		}	
	}

	void ManageLOD(){
		
		//manage Level Of Detail
		if(deactivate_when_tooFar && (Mathf.Abs( Camera.main.transform.position.x - transform.position.x ) > distanceActivebyX ) ) {

			//detach to avoid being disabled
			if(tempParent.transform.childCount > 0){
				transform.parent = null ; //detach LOD	
			}
			tempParent.SetActive(false);
		}

		if(activate_when_Near &&  (Mathf.Abs( Camera.main.transform.position.x - transform.position.x ) < distanceActivebyX )){
			if(tempParent){
				transform.SetParent(tempParent.transform);
			}
			tempParent.SetActive(true);	
		}			
	}

	public void DeactivateGameObj(GameObject objRef) {

		objRef.SetActive(false);

	}
	public void ActivateGameObj(GameObject objRef) {

		objRef.SetActive(true);

	}
}
