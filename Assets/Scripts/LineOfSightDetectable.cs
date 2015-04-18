using UnityEngine;
using System.Collections;

public class LineOfSightDetectable : MonoBehaviour {


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "LineOfSight") {
			GameObject youSeeMe = other.transform.parent.gameObject;

			//Debug.Log("You see me! " + youSeeMe.name);
			youSeeMe.BroadcastMessage("OnLineOfSightEnter", gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "LineOfSight") {
			GameObject youSeeMe = other.transform.parent.gameObject;

			//Debug.Log("You don't see me! " + youSeeMe.name);
			youSeeMe.BroadcastMessage("OnLineOfSightExit", gameObject, SendMessageOptions.DontRequireReceiver);
		}
	}

}
