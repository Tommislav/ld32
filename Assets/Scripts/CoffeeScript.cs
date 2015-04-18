using UnityEngine;
using System.Collections;

public class CoffeeScript : MonoBehaviour {

	public static int CoffeeCount;

	void Start () {
		CoffeeCount++;
	}

	void OnDestroy() {
		CoffeeCount--;
	}
	
}
