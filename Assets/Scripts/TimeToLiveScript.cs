using UnityEngine;
using System.Collections;

public class TimeToLiveScript: MonoBehaviour {


	public float TimeToLive = 10f;

	
	void Update () {
		TimeToLive -= Time.deltaTime;
		if (TimeToLive <= 0) {
			Destroy(gameObject);
		}
	}
}
