using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

	public Vector3 axis = new Vector3(0.1f, 0.1f, 0.2f);
	public float angle = 1f;
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(axis, angle);
	}
}
