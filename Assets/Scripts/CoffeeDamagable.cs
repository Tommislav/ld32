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
	
	}

	void OnCollisOnCollisionEnter(Collision coll) {
		if (coll.gameObject.tag == "Coffee") {
			Destroy(coll.gameObject);
			AmountOfCoffeePerHp--;

			if (AmountOfCoffeePerHp <= 0) {
				
			}
		}
	}
}
