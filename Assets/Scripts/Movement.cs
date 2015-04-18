using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public float distToGround = 0.03f;
	private MoveData _move;

	private Rigidbody _rigidBody;
	//private Animator _animator;

	[HideInInspector]
	public float facingAngle = 0f;
	private Vector3 _moveDir;

	private int _groundLayerMask;

	void Start() {
		_move = GetComponent<MoveData>();
		_rigidBody = GetComponent<Rigidbody>();
		//_animator = GetComponent<Animator>();

		_groundLayerMask = LayerMask.NameToLayer("Ground");

		float initialRotation = Mathf.Round(transform.rotation.eulerAngles.y);
		
		_move.MoveAngle = initialRotation;
		_moveDir = getVectorFromAngle(initialRotation);
	}

	void FixedUpdate() {
		_moveDir = getVectorFromAngle(_move.MoveAngle);
		Vector3 velocity = _moveDir * (_move.Speed * _move.MaxSpeed);
		velocity.y = _rigidBody.velocity.y;

		_rigidBody.velocity = velocity;
	}
	
	void Update () {
		
		if (_move.Speed < 0 && !_move.FlippedX) {
			setDir (-1);
		} else if (_move.Speed > 0 && _move.FlippedX) {
			setDir(1);
		}

		_move.Grounded = IsGrounded();

		if ( _move.JumpKeyIsDown && _move.Grounded) {
			_rigidBody.AddForce(new Vector2(0.0f, _move.JumpStr));
			_move.Grounded = false;
		}
	}

	public bool IsGrounded() {
		return Physics.Raycast(_rigidBody.transform.position, -Vector3.up, distToGround);
	}

	private void setDir(int dir) {

		float rotTarget = (dir == -1) ? -facingAngle + 180 : -facingAngle;
		LeanTween.cancel(gameObject);
		LeanTween.rotate(gameObject, new Vector3(0f, rotTarget, 0f), 0.25f);
		_move.FlippedX = !_move.FlippedX;	
	}

	private Vector3 getVectorFromAngle(float angle) {
		float moveRad = angle / 180 * Mathf.PI;
		float x = Mathf.Cos(moveRad);
		float z = -Mathf.Sin(moveRad);


		return new Vector3(x, 0f, z);
	}

	public void SetFacingAngle(float angle) {
		_move.MoveAngle = angle;
		_moveDir = getVectorFromAngle(angle);
		
		float rotTarget = (_move.FlippedX) ? angle + 180 : angle;
		LeanTween.rotate(gameObject, new Vector3(0f, rotTarget, 0f), 0.25f);

		LeanTween.value(gameObject, updateFacingAngleFromAnimation, facingAngle, -angle, 1.3f).setEase(LeanTweenType.easeInOutQuart);
	}

	private void updateFacingAngleFromAnimation(float value) {
		facingAngle = value;
	}
}
