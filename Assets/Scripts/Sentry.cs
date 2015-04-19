using UnityEngine;
using System.Collections;

public class Sentry : MonoBehaviour {

	private bool _dead;
	private float _removalTime = 2f;
	
	void Start () {
	
	}
	
	
	void Update () {
		if (_dead) {
			transform.Rotate(new Vector3(2, 1, 0.5f));

			_removalTime -= Time.deltaTime;
			if (_removalTime <= 0) {
				Destroy(gameObject);
			}
		}
	}

	public void OnDie() {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.useGravity = true;
		rb.AddForce(0,400,0);
		_dead = true;

	}
}
