using UnityEngine;
using System.Collections;

public class CoffeeDamagable : MonoBehaviour {

	public int AmountOfCoffeePerHp = 10;
	private int _refillAmount;


	private Health _health;

	void Start () {
		_health = GetComponent<Health>();
		_refillAmount = AmountOfCoffeePerHp;
	}
	
	void Update () {
		if (transform.position.y < -50f) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Coffee") {
			Destroy(coll.gameObject);

			if (_health.CanRecieveDamage()) {
				AmountOfCoffeePerHp--;

				if (AmountOfCoffeePerHp <= 0) {
					_health.ReduceHealth();
					AmountOfCoffeePerHp = _refillAmount;
				}
			}
			
		}
	}

	/*
	void OnCollisOnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Coffee") {
			Debug.Log("OnCollisOnCollisionEnter " + coll.gameObject.name);
		}

	}
	 */
}
