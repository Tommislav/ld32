using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {

	private Animator _animator;

	private Transform _player;
	private bool _rotateTowardsPlayer;
	private string _bossFightState;


	private bool _isActive;


	// Use this for initialization
	void Start () {
		_animator = GetComponent<Animator>();
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

	public void ShakeGround() {
		GetComponent<ShakeCameraScript>().ShakeCamera();
	}


	public void StartBossFight() {
		_isActive = true;
		_player = GameObject.Find("/Player").transform;	
		LeanTween.rotateY(gameObject, 270, 0.75f).setEase(LeanTweenType.easeOutQuad);
		_animator.SetTrigger("startFight");

		_bossFightState = "idle";
	}



	// Update is called once per frame
	void Update() {
		if (_isActive) {

			float dist = _player.transform.position.x - transform.position.x;

			if (_bossFightState == "idle") {
				if (dist < 3) {
					_animator.SetTrigger("smash1");
				}
			}

			

			

		}
	}


	void OnDie() {
		_isActive = false;
		_animator.SetTrigger("die");
	}

}
