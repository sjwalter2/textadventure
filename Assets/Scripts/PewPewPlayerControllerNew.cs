using UnityEngine;
using System.Collections;

public class PewPewPlayerControllerNew : MonoBehaviour {
	public float speed;
	public float xMin, xMax, zMin, zMax;
	//public Boundary boundary;
	public float tilt;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	public string dxn;
	
	// Use this for initialization
	void Start () {
		dxn = "up";
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			Debug.Log ("firing");
			nextFire = Time.time + fireRate;
			GameObject clone = Instantiate (shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
		}
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		rigidbody.velocity = new Vector3 (moveHorizontal*speed, 0.0f, moveVertical*speed);
		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, xMin, xMax),
			0f,
			Mathf.Clamp (rigidbody.position.z, zMin, zMax)
			);
		if (dxn == "up") {
			rigidbody.rotation = Quaternion.Euler (0f, 0f, rigidbody.velocity.x * -tilt);
		} else if (dxn == "down") {
			rigidbody.rotation = Quaternion.Euler (0f, 180f, rigidbody.velocity.x * -tilt);
		}
	}
}


//Disabled so i can edit the damn bounding box from gamecontroller for resize.
/*
[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}
*/
