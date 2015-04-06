using UnityEngine;
using System.Collections;

public class BoltMover : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		rigidbody.velocity = transform.forward*speed;

		//must be rotated after instantiation, or its axes will be all wrong and it will start moving _up_
		if (this.tag != "Projectile") {
			transform.rotation = Quaternion.Euler (90, 0, 0);
		}
		//Debug.Log (this.GetType ());

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
