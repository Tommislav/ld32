using UnityEngine;
using System.Collections;

public class SpawnBulletsScript : MonoBehaviour {

	public GameObject SpawnPrefab;
	public Transform SpawnPoint;
	public float SpawnSpeed;
	public float SpawnInterval;
	public bool IsRunning = true;

	public int NumberOfSpawns = 5;
	public float TimeBetweenSpawns = 0.2f;
	public float TimeBetweenSpawnsRnd = 0.01f;


	private float _counter = 0f;
	private bool _isSpawning;
	


	// Use this for initialization
	void Start () {
		_counter = SpawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if (IsRunning && !_isSpawning) {
			_counter -= Time.deltaTime;
			if (_counter <= 0f) {
				ResetCounter();
				StartCoroutine(SpawnObjects());
			}
		}
	}


	private IEnumerator SpawnObjects() {
		_isSpawning = true;

		int numSpawns = NumberOfSpawns;

		while (numSpawns-- > 0) {
			SpawnObject();

			if (numSpawns > 0) {
				float nextTime = TimeBetweenSpawns + (Random.value * TimeBetweenSpawnsRnd);
				yield return new WaitForSeconds(nextTime);
			}
		}
		_isSpawning = false;
	}


	public void ResetCounter() {
		_counter = SpawnInterval;
	}

	public void SpawnObject() {
		GameObject go = Instantiate<GameObject>(SpawnPrefab);
		go.transform.position = SpawnPoint.position;
		go.transform.rotation = SpawnPoint.rotation;

		Rigidbody rb = go.GetComponent<Rigidbody>();
		rb.AddForce(go.transform.up * SpawnSpeed);
	}

	public void OnDie() {
		IsRunning = false;
	}
}
