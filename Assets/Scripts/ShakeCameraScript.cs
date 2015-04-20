using UnityEngine;
using System.Collections;

public class ShakeCameraScript : MonoBehaviour {

	private Vector3 _cameraOffset;
	private int _shakeCounter;
	private Camera _camera;

	public AudioClip SmashSound;

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
					Random.value * 0.8f,
					Random.value * 0.8f,
					Random.value * 0.8f
				);
				_camera.transform.Translate(_cameraOffset);
			}
			
		}
	}


	public void ShakeCamera() {
		_shakeCounter = 10;

		GameObject player = GameObject.Find("/Player");
		AudioSource audio = player.GetComponent<AudioSource>();
		audio.PlayOneShot(SmashSound);
	}
}
