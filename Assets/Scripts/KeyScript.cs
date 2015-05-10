using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {

	public GameObject Lock;
	public GameObject[] DecorateLocks;

	private bool _invoked;


	void OnTriggerEnter(Collider coll) {
		if (!_invoked) {
			if (coll.gameObject.tag == "Player") {
				_invoked = true;

				if (Lock != null) {
					GetComponent<AutoRotate>().RotationEnabled = false;
					LeanTween.moveY(gameObject, transform.position.y + 1f, 0.5f).setEase(LeanTweenType.easeOutCubic);
					LeanTween.rotate(gameObject, Lock.transform.rotation.eulerAngles, 0.7f).setDelay(0.3f);
					LeanTween.move(gameObject, Lock.transform.position, 0.6f).setDelay(1f).setOnComplete(OnAnimationComplete);
				} else {
					SendMessage("OnGroundTrigger", SendMessageOptions.DontRequireReceiver);
					GameObject.Destroy(gameObject);
				}
			}
			
		}
	}

	private void OnAnimationComplete() {
		GameObject.Destroy(gameObject);
		GameObject.Destroy(Lock);

		foreach (GameObject go in DecorateLocks) {
			GameObject.Destroy(go);
		}

		SendMessage("OnGroundTrigger", SendMessageOptions.DontRequireReceiver);
	}

}
