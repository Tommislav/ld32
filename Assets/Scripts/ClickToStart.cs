using UnityEngine;
using System.Collections;

public class ClickToStart : MonoBehaviour {


	public float TimeToWait = 2f;

	void Update() {
		TimeToWait -= Time.deltaTime;
		if (TimeToWait <= 0) {
			StartGame();
		}
	}


	public void StartGame() {
		Application.LoadLevel("GameScene");
	}
}
