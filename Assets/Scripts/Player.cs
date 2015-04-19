using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject CoffeeParticle;

	public bool StartWithCup = false;

	private GameObject _attack;
	private GameObject _pourCoffePos;
	private bool _hasWeapon;
	private bool _canAttack;
	private bool _isAttacking;
	private bool _isPouring;
	private MoveData _move;

	void Start() {
		_attack = GameObject.Find("Cup");
		_pourCoffePos = GameObject.Find("PourCoffe");
		_move = GetComponent<MoveData>();
		_canAttack = StartWithCup;
		_attack.SetActive(StartWithCup);
	}



	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			if (_canAttack && !_isAttacking) {
				_isAttacking = true;
				LeanTween.rotateLocal(_attack, new Vector3(0f, 0f, -60f), 0.18f).setOnComplete(StartPourCoffee);
			}
		}

		if (Input.GetButton("Fire1")) {}
		else {
			if (_isAttacking) {
				_isAttacking = false;
				_isPouring = false;
				LeanTween.cancel(_attack);
				LeanTween.rotateLocal(_attack, new Vector3(0f, 0f, 0f), 0.18f);
			}
		}

		if (_isPouring) {

			int particleNum = CoffeeScript.CoffeeCount > 400 ? 5 : 10;

			for (int i = 0; i < particleNum; i++) {
				MakeCoffee();
			}
		}
	}


	private void MakeCoffee() {
		GameObject coffee = Instantiate<GameObject>(CoffeeParticle);

		float rx = Random.Range(-0.01f, 0.01f);
		float ry = Random.Range(-0.01f, 0.01f);
		float rz = Random.Range(-0.01f, 0.01f);
		float rs = Random.Range(0.008f, 0.012f);

		coffee.transform.position = _pourCoffePos.transform.position + new Vector3(rx,ry,rz);
		Rigidbody rb = coffee.GetComponent<Rigidbody>();

		Vector3 force = _pourCoffePos.transform.up*(rs + (Mathf.Abs(_move.Speed)*0.022f));
		rb.AddForce(force);

		//coffee.transform.rotation = _pourCoffePos.transform.localRotation;
	}

	private void StartPourCoffee() {
		_isPouring = true;
	}







	public void OnCoffeCupRecieved() {
		_canAttack = true;
		_attack.SetActive(true);
	}



	void OnTriggerEnter(Collider other) {
		if (other.name == "RemoveStartAreaTrigger") {
			Destroy(other.gameObject);

			GameObject go = GameObject.Find("StartArea");
			Destroy(go);
		}

		if (other.name == "StartBossAnimation") {
			Destroy(other.gameObject);
			GameObject go = GameObject.Find("Boss");
			go.GetComponent<BossScript>().StartIntro(this.transform);
			
		}

		if (other.name == "StopBossAnimation") {
			Destroy(other.gameObject);
			GameObject go = GameObject.Find("Boss");
			go.GetComponent<BossScript>().StopIntro();

		}
	}
}
