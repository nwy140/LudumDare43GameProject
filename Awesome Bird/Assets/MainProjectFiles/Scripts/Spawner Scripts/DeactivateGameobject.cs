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
		if(deactivate_when_tooFar && (Vector2.Distance(Camera.main.transform.position, transform.position) > 35f))
		DeactivateGameObj ();

		if(activate_when_Near &&  (Vector2.Distance(Camera.main.transform.position, transform.position) < 35f))
		ActivateGameObj();
	}

	public void DeactivateGameObj() {
		//toofar
			//disable movement
  			myBody.constraints = RigidbodyConstraints2D.FreezeAll;
			print("deactivate obj : " + gameObject.name);
			
	}
	public void ActivateGameObj() {
		//near
			//enable movement
            myBody.constraints = RigidbodyConstraints2D.None;
			myBody.constraints = RigidbodyConstraints2D.FreezeRotation;
			print("activate obj : " + gameObject.name);

	

	}


}
