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
	}

	void OnDisable () {
		PewPewEventManager.onDestroy -= UpdateVelocity;
	}

	void Awake () {
		dxn = "up";
	}
	// Use this for initialization
	void Start () {
		GameObject gco = GameObject.FindWithTag ("GameController");
		gc = gco.GetComponent <PewPewGameController> ();

		speed = gc.texteroidSpeed;
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
	}

	void UpdateVelocity(float speed) {
		Debug.Log ("vlct is " + velocity);
		velocity = transform.up * speed;
	}
}
