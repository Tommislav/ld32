using UnityEngine;
using System.Collections;

public class MoveTurnAtEdgeScript : MonoBehaviour {

	private float _moveLeftAngle;
	private float _moveRightAngle;
	private float _lastDistance;
	private bool _playerFacingUpdated;
	

	private Movement _movement;
	private MoveData _move;
	private Transform _triggerTransform;

	void Start() {
		_move = GetComponent<MoveData>();
		_movement = GetComponent<Movement>();
	}
	
	
	void Update () {
		if (_triggerTransform != null) {

			float distFromCenter = Calc2DDistance();
			bool movingAwayFromCenter = Mathf.Abs(distFromCenter) > Mathf.Abs(_lastDistance);
			_lastDistance = distFromCenter;

			if (movingAwayFromCenter && !_playerFacingUpdated) {
				_playerFacingUpdated = true;

				float angle = _move.Speed > 0 ?
					_moveRightAngle : _moveLeftAngle;

				_movement.SetFacingAngle(angle);

				
			} else {
				_playerFacingUpdated = false;
			}
		}
	}

	private float Calc2DDistance() {
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
			_lastDistance = Calc2DDistance();

			TurnNode edge = other.gameObject.GetComponent<TurnNode>();
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
