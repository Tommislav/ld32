using UnityEngine;
using System.Collections;

public class ShakeCameraScript : MonoBehaviour {

	private Vector3 _cameraOffset;
	private int _shakeCounter;
	private Camera _camera;

	void Start () {
		_cameraOffset = new Vector3();
		_camera = Camera.main;
	}
	
	void Update () {
		if (_shakeCounter > 0) {
			_shakeCounter--;

			_camera.transform.Translate(-_cameraOffset);

			if (_shakeCounter == 0) {
				_cameraOffset = Vector3.zero;
			} else {
				_cameraOffset = new Vector3(
					Random.value,
					Random.value,
					Random.value
				);
				_camera.transform.Translate(_cameraOffset);
			}
			
		}
	}


	public void ShakeCamera() {
		_shakeCounter = 10;
	}
}
