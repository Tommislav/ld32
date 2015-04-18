using UnityEngine;
using System.Collections;

public class PatrolAIScript : MonoBehaviour {

	public int WalkCycleFrames = 400;
	public int WalkCycleOffset = 0;
	public bool StartWalkingRight = false;
	public int PauseFrames = 20;
	public int PauseFramesOffset = 0;

	public float PatrolSpeed = 1f;
	public float AlertSpeed = 4f;

	private int _dir = 1;
	public bool _canSeePlayer;

	private MoveData _moveData;
	private float _currentSpeed = 0;
	public int _counter;
	public int _pauseCounter;


	void Start() {
		_moveData = GetComponent<MoveData>();
		_dir = StartWalkingRight ? 1 : -1;
		_currentSpeed = PatrolSpeed;
		_counter = WalkCycleFrames - WalkCycleOffset;
		_pauseCounter = PauseFramesOffset;
	}

	void Update () {
		if (_pauseCounter > 0) {
			_pauseCounter--;
		} else if (_counter > 0) {
			_counter--;
		}


		if (_canSeePlayer) {
			_moveData.Speed = _currentSpeed*_dir;
		}
		else {
			if (_pauseCounter > 0) {
				_moveData.Speed = 0;
			} else if (_counter <= 0) {

				_dir = -_dir;
				_counter = WalkCycleFrames;
				_pauseCounter = PauseFrames;
			} else {
				_moveData.Speed = _currentSpeed * _dir;
			}
		}

	}


	void OnLineOfSightEnter(GameObject go) {
		_currentSpeed = AlertSpeed;
		_canSeePlayer = true;
	}

	void OnLineOfSightExit(GameObject go) {
		_currentSpeed = PatrolSpeed;
		_canSeePlayer = false;
	}
}
