using UnityEngine;
using System.Collections;

public class PewPewTexteroidMover : MonoBehaviour {
	private float speed;
	public string dxn;
	private Vector3 velocity;
	public bool paused;
	private PewPewGameController gc;

	void OnEnable () {
		PewPewEventManager.onDestroy += UpdateVelocity;
		PewPewEventManager.onPause += pause;
	}

	void OnDisable () {
		PewPewEventManager.onDestroy -= UpdateVelocity;
		PewPewEventManager.onPause -= pause;
	}

	void Awake () {
		//dxn = "down";
	}
	// Use this for initialization
	void Start () {
		GameObject gco = GameObject.FindWithTag ("GameController");
		gc = gco.GetComponent <PewPewGameController> ();

		speed = gc.texteroidSpeed;
		paused = false;
		//dxn = "up";
		velocity = transform.forward * speed;
		if(dxn == "up") {
			rigidbody.velocity = velocity;
		} else if (dxn == "down"){
			rigidbody.velocity = -velocity;
		}


		//must be rotated after instantiation, or its axes will be all wrong and it will start moving _up_
		if (this.tag != "Projectile") {
			transform.rotation = Quaternion.Euler (90, 0, 0);
		}
		//Debug.Log (this.GetType ());

	}

	void pause ()
	{
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

	void FixedUpdate () {
		//Debug.Log ("gcspd is " + gc.texteroidSpeed);
		//velocity = transform.up * gc.texteroidSpeed;

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

	void UpdateVelocity(float speed) {
		velocity = transform.up * speed;
		//Debug.Log ("vlct is " + velocity);

		if (dxn == "down") {
			rigidbody.velocity = -velocity;
		} else if (dxn == "up") {
			rigidbody.velocity = velocity;
		}
	}
}
