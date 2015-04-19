using UnityEngine;
using System.Collections;

public class WobbleSineScript : MonoBehaviour {


	public float WobbleY;
	public float WobbleSpeed;

	private float _wobbleY = 0;
	private float _wobbleCount = 0;

	void Start () {
	
	}
	
	void Update () {

		transform.position -= new Vector3(0, _wobbleY, 0);

		_wobbleCount += WobbleSpeed;
		_wobbleY = Mathf.Sin(_wobbleCount) * WobbleY;

		transform.position += new Vector3(0, _wobbleY, 0);
	}

	public void OnDie() {
		this.enabled = false;
	}
}
