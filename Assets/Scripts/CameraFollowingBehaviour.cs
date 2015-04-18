using UnityEngine;
using System.Collections;

public class CameraFollowingBehaviour : MonoBehaviour {

	public GameObject tracker;
	public bool is3dCamera;

	private float _lastTrackX;
	private float _lastTrackY;

	private float _diffZ;

	private Vector3 _offset;
	private float _lastRot;

	private Transform _transform;
	private PlayerMovement _playerMovement;


	// Use this for initialization
	void Start () {
		_transform = tracker.GetComponent<Transform>();
		_playerMovement = tracker.GetComponent<PlayerMovement>();
		_lastRot = 0f;

		_offset = transform.position - _transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 vec = _transform.position + _offset;
		this.transform.position = vec;

		if (_playerMovement.facingAngle != _lastRot) {
			_lastRot = _playerMovement.facingAngle * -1;

			transform.rotation = Quaternion.identity;
			transform.Rotate(0f, _lastRot, 0f);
		}
	}
}
