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

			LeanTween.moveY(stair1, 0.3f, 1.5f).setDelay(1f);
			LeanTween.moveY(stair2, -0.7f, 1f).setDelay(2.5f);
			LeanTween.moveY(stair3, -1.7f, 0.5f).setDelay(3.5f);

			coll.GetComponent<AudioSource>().PlayOneShot(PickupSound);

			Destroy(gameObject);
		}
	}
}
