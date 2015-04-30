using UnityEngine;
using System.Collections;

public class PewPewBoltMover : MonoBehaviour {
	public float speed;
	public string dxn;
	private Vector3 velocity;
	public bool paused;

	void Awake () {
		dxn = "up";
	}

	void OnEnable () {
		PewPewEventManager.onPause += pause;
	}
	
	void OnDisable () {
		PewPewEventManager.onPause -= pause;
	}
	// Use this for initialization
	void Start () {
		paused = false;
		//dxn = "up";
		velocity = transform.forward * speed;
		rigidbody.velocity = velocity;

		//must be rotated after instantiation, or its axes will be all wrong and it will start moving _up_
		if (this.tag != "Projectile") {
			transform.rotation = Quaternion.Euler (90, 0, 0);
		}
		//Debug.Log (this.GetType ());

	}
	
	// Update is called once per frame
	void Update () {
//		if (paused) {
//			rigidbody.velocity = Vector3.zero;
//		} else {
//			if (dxn == "down") {
//				rigidbody.velocity = -velocity;
//			} else if (dxn == "up") {
//				rigidbody.velocity = velocity;
//			}
//		}
	}

	public void swopdxn() {
		if (dxn == "down") {
			dxn = "up";
		} else if (dxn == "up") {
			dxn = "down";
		}

		if (dxn == "down") {
			rigidbody.velocity = -velocity;
		} else if (dxn == "up") {
			rigidbody.velocity = velocity;
		}
	}

	public void pause() {
		paused = !paused;
		if (paused) {
			rigidbody.velocity = Vector3.zero;
		} else {
			if (dxn == "down") {
				rigidbody.velocity = -velocity;
			} else if (dxn == "up") {
				rigidbody.velocity = velocity;
			}
		}
	}
}
