using UnityEngine;
using System.Collections;

public class WeaponHurtable : MonoBehaviour {

	private Health _health;


	void Start() {
		_health = GetComponent<Health>();
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Weapon") {

			if (_health.CanRecieveDamage()) {
				_health.ReduceHealth();
			}
		}
	}

}
