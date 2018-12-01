using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameobject : MonoBehaviour {
	public bool deactivate_when_tooFar = true;
	public bool activate_when_Near = true;

	private Rigidbody2D myBody;
	
	
	void Awake(){
		myBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if(deactivate_when_tooFar)
		DeactivateGameObj ();

		if(activate_when_Near)
		ActivateGameObj();
	}

	void DeactivateGameObj() {
		//toofar
		if (Vector2.Distance(Camera.main.transform.position, transform.position) > 35f) {
			//disable movement
  			myBody.constraints = RigidbodyConstraints2D.FreezeAll;
			print("deactivate obj : " + gameObject.name);
			
		}

	}
	void ActivateGameObj() {
		//near
		if (Vector2.Distance(Camera.main.transform.position, transform.position) < 35f) {
			//enable movement
            myBody.constraints = RigidbodyConstraints2D.None;
			myBody.constraints = RigidbodyConstraints2D.FreezeRotation;
			print("activate obj : " + gameObject.name);

		}

	}
}
