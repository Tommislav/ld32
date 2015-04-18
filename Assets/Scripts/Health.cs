using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HP = 3;
	public float DamageCooldownTime = 1f;
	public bool JumpWhenHurt;
	public float JumpStr = 600f;

	private float _lastDamageTime = 0f;


	public bool CanRecieveDamage() {
		return ((Time.time - DamageCooldownTime) > (_lastDamageTime));
	}

	public void ReduceHealth() {
		HP--;
		_lastDamageTime = Time.time;
		if (HP == 0) {
			SendMessage("OnDie", SendMessageOptions.DontRequireReceiver);

			Collider[] colls = GetComponents<Collider>();
			foreach (Collider coll in colls) {
				coll.enabled = false;
			}


		}
		
		if (JumpWhenHurt) {
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.velocity = Vector3.zero;
			rb.AddForce(new Vector3(0, JumpStr, 0));
		}
	}
}
