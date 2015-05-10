using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour {

	public Vector3 axis = new Vector3(0.1f, 0.1f, 0.2f);
	public float angle = 1f;

	public bool RotationEnabled = true;

	// Update is called once per frame
	void Update () {
		if (RotationEnabled) {
			this.transform.Rotate(axis, angle);
		}
	}
}
