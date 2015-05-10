using UnityEngine;
using System.Collections;

public class PickupCoffee : MonoBehaviour {

	public GameObject stair1;
	public GameObject stair2;
	public GameObject stair3;

	public AudioClip PickupSound;

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			
			coll.gameObject.GetComponent<Player>().OnCoffeCupRecieved();
			coll.GetComponent<AudioSource>().PlayOneShot(PickupSound);

			Destroy(gameObject);
		}
	}
}
