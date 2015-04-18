using UnityEngine;
using System.Collections;

public class PlayerTurnAtEdgeScript : MonoBehaviour {

	private float _moveLeftAngle;
	private float _moveRightAngle;
	private float _lastDistance;
	private bool _playerFacingUpdated;
	

	private PlayerMovement _playerMovement;
	private MoveData _move;
	private Transform _triggerTransform;

	void Start() {
		_move = GetComponent<MoveData>();
		_playerMovement = GetComponent<PlayerMovement>();
	}
	
	
	void Update () {
		if (_triggerTransform != null) {

			float distFromCenter = calc2dDistance();
			bool movingAwayFromCenter = Mathf.Abs(distFromCenter) > Mathf.Abs(_lastDistance);
			_lastDistance = distFromCenter;

			Debug.Log("dist: " + distFromCenter + ", moveAway:" + movingAwayFromCenter);

			if (movingAwayFromCenter && !_playerFacingUpdated) {
				_playerFacingUpdated = true;

				float angle = _move.Speed > 0 ?
					_moveRightAngle : _moveLeftAngle;

				_playerMovement.SetFacingAngle(angle);

				
			} else {
				_playerFacingUpdated = false;
			}
		}
	}

	private float calc2dDistance() {
		if (_triggerTransform == null) {
			return 0f;
		}

		float dx = _triggerTransform.position.x - transform.position.x;
		float dz = _triggerTransform.position.z - transform.position.z;
		return (Mathf.Sqrt(dx*dx + dz*dz));
	}


	public void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Turn") {
			_triggerTransform = other.gameObject.GetComponent<Transform>();
			_lastDistance = calc2dDistance();

			EdgeScript edge = other.gameObject.GetComponent<EdgeScript>();
			_moveLeftAngle = edge.MoveLeftAngle;
			_moveRightAngle = edge.MoveRightAngle;
		}
	}

	public void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Turn") {
			_triggerTransform = null;
		}
	}
}
