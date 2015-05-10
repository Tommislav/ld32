using UnityEngine;
using System.Collections;

public class MoveGroundTrigger : MonoBehaviour {

	public bool TriggerOnCollision;
	public TriggerInfo[] Triggers;
	

	private bool _isTriggered;


	void OnTriggerEnter(Collider coll) {
		Debug.Log("MoveGroundTrigger invoked!!");
		if (TriggerOnCollision) {
			if (!_isTriggered) {
				if (coll.gameObject.tag == "Player") {
					OnGroundTrigger();
				}
			}
		}
	}


	


	public void OnGroundTrigger() {
		if (!_isTriggered) {
			
			_isTriggered = true;

			foreach (TriggerInfo info in Triggers) {
				LeanTween.moveY(
					info.Target,
					info.EndY,
					info.Time
				).setDelay(info.Delay);

			}

			GameObject.Destroy(gameObject);
		}
	}


	[System.Serializable]
	public class TriggerInfo {
		public GameObject Target;
		public float Delay;
		public float StartY;
		public float EndY;
		public float Time;
	}
}


