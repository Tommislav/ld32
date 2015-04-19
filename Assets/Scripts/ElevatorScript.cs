using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {

	public Transform ElevatorPlatform;
	public float ToY;
	public float WaitAtTop;
	public float UpSpeed;
	public float DownSpeed;

	private Vector3 _startPos;
	private bool _isWorking;
	private bool _isGoingUp;
	private float _waitTime;

	void Start() {
		_startPos = ElevatorPlatform.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (_isWorking) {

			if (_isGoingUp) {
				ElevatorPlatform.transform.position += new Vector3(0, UpSpeed, 0);
				if (ElevatorPlatform.transform.position.y >= ToY) {

					_isGoingUp = false;
					ElevatorPlatform.transform.position = new Vector3(
						ElevatorPlatform.transform.position.x,
						ToY,
						ElevatorPlatform.transform.position.z
					);
				}
			} 
			else if (_waitTime > 0) {
				_waitTime -= Time.deltaTime;
			} 
			else { // going down
				ElevatorPlatform.transform.position -= new Vector3(0, DownSpeed, 0);

				if (ElevatorPlatform.transform.position.y <= _startPos.y) {
					ElevatorPlatform.transform.position = _startPos;
					_isWorking = false;
				}
			}

		}
	}

	public void StartElevator() {
		if (!_isWorking) {
			_isWorking = true;
			_isGoingUp = true;
			_waitTime = WaitAtTop;
		}
	}
}
