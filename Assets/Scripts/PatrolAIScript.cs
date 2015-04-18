using UnityEngine;
using System.Collections;

public class PatrolAIScript : MonoBehaviour {

	public int WalkCycleFrames = 400;
	public int WalkCycleOffset = 0;
	public bool StartWalkingRight = false;
	public int PauseFrames = 20;
	public int PauseFramesOffset = 0;


	private MoveData _moveData;
	private float _currentSpeed = 0;
	public int _counter;
	public int _pauseCounter;

	void Start() {
		_moveData = GetComponent<MoveData>();
		_currentSpeed = StartWalkingRight ? _moveData.MaxSpeed : -_moveData.MaxSpeed;
		_counter = WalkCycleFrames - WalkCycleOffset;
		_pauseCounter = PauseFramesOffset;
	}

	void Update () {
		if (_pauseCounter > 0) {
			_moveData.Speed = 0;
			_pauseCounter--;
		}
		else {
			_counter--;
			if (_counter <= 0) {

				_currentSpeed = -_currentSpeed;
				_counter = WalkCycleFrames;
				_pauseCounter = PauseFrames;
			}
			else {
				_moveData.Speed = _currentSpeed;
			}
			

		}


		
	}
}
