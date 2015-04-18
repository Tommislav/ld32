using UnityEngine;
using System.Collections;

public class WeaponHurtable : MonoBehaviour {

	public float InvinciblePeriod = 1f;
	private float _lastPointOfContact = 0f;

	public bool JumpWhenHurt = true;

	private Rigidbody _rigidBody;
	private MoveData _moveData;

	void Start() {
		_rigidBody = GetComponent<Rigidbody>();
		_moveData = GetComponent<MoveData>();
	}


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Weapon") {

			float now = Time.time;
			if ((now-InvinciblePeriod) > (_lastPointOfContact)) {
				_lastPointOfContact = now;
				Debug.Log("AAAJ " + now);

				if (JumpWhenHurt) {
					_rigidBody.velocity = Vector3.zero;
					_rigidBody.AddForce(new Vector3(0, _moveData.JumpStr, 0));
					_moveData.Grounded = false;
				}
				
			}

		}
	}

}
