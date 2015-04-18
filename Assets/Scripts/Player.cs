using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {




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
