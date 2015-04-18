using UnityEngine;
using System.Collections;

public class LineOfSightScript : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log("I SEE YOU " + other.gameObject.name);
	}

	void OnTriggerExit(Collider other) {
		Debug.Log("I DON'T SEE YOU ANYMORE " + other.gameObject.name);
	}
}
