using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndCredits : MonoBehaviour {

	public Image Credits;
	public float EndY;
	public string NextScene;

	private RectTransform _r;

	void Start() {
		_r = GetComponent<RectTransform>();
	}

	void Update () {

		Credits.rectTransform.Translate(0, 0.5f, 0);

		if (Credits.rectTransform.position.y > EndY) {
			Application.LoadLevel(NextScene);
		}
	}
}
