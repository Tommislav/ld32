using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float distToGround = 0.5f;
	private MoveData _move;

	private Rigidbody _rigidBody;
	//private Animator _animator;

	public float facingAngle = 0f;
	private Vector3 _moveDir;


	void Start() {
		_move = GetComponent<MoveData>();
		_rigidBody = GetComponent<Rigidbody>();
		//_animator = GetComponent<Animator>();
		_moveDir = getVectorFromAngle(0);
	}

	void FixedUpdate() {
		_moveDir = getVectorFromAngle(_move.MoveAngle);
		Vector3 velocity = _moveDir * (_move.Speed * _move.MaxSpeed);
		velocity.y = _rigidBody.velocity.y;

		_rigidBody.velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
		_move.Speed = Input.GetAxis ("Horizontal");

		if (_move.Speed < 0 && !_move.FlippedX) {
			setDir (-1);
		} else if (_move.Speed > 0 && _move.FlippedX) {
			setDir(1);
		}

		_move.Grounded = IsGrounded();
		//_animator.SetBool("inAir", !_move.Grounded);
		//_animator.SetBool("isWalking", (_move.Speed < -0.1f || _move.Speed > 0.1f));

		if (Input.GetButtonDown ("Jump") && _move.Grounded) {
			_rigidBody.AddForce(new Vector2(0.0f, _move.JumpStr));
			_move.Grounded = false;
		}
	}

	public bool IsGrounded() {
		return Physics.Raycast(_rigidBody.transform.position, -Vector3.up, distToGround + 0.1f);
	}

	private void setDir(int dir) {

		float rotTarget = (dir == -1) ? -facingAngle + 180 : -facingAngle;
		LeanTween.cancel(gameObject);
		LeanTween.rotate(gameObject, new Vector3(0f, rotTarget, 0f), 0.25f);
		_move.FlippedX = !_move.FlippedX;	
	}

	private Vector3 getVectorFromAngle(float angle) {
		float moveRad = _move.MoveAngle / 180 * Mathf.PI;
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
