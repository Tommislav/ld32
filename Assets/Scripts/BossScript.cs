using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	private Animator _animator;

	private Transform _player;
	private bool _rotateTowardsPlayer;



	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void StartIntro(Transform player) {
		_rotateTowardsPlayer = true;
		_animator.SetTrigger("playIntro");
		_player = player;
	}

	public void StopIntro() {
		_rotateTowardsPlayer = false;
		_player = null;
	}

	public void ShakeCamera() {
		GetComponent<ShakeCameraScript>().ShakeCamera();
	}


	

}
