using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;

public class StateData : MonoBehaviour {

	public static StateData Instance;



	public bool BossFightStarted;



	void Awake() {
		Instance = this;
	}
}
