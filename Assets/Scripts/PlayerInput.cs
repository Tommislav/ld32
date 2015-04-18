using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private MoveData _move;
	void Start () {
		_move = GetComponent<MoveData>();
	}
	
	// Update is called once per frame
	void Update () {
		_move.Speed = Input.GetAxis("Horizontal");

		_move.JumpKeyIsDown = Input.GetButtonDown("Jump");
	}
}
