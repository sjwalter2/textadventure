using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}
public class ChrisPlayerController : MonoBehaviour {
	public float speed;
	public float tilt;
	public Boundary boundary;
	public Vector3 Gravity;
	public GUIText CountText;
	public float Variation;
	static public Vector3 myPosition;
	static public float gameSpeed = 1;
	static public int count;

	void Start(){
		count = 0;
		CountText.text = "Count: " + count.ToString();
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float movementSpeed = (transform.position.x + 1.0f) * speed/3;
		Vector3 movement = new Vector3 (moveHorizontal*4, 0.0f, moveVertical*movementSpeed);
		rigidbody.velocity = movement;
		gameSpeed = movementSpeed;
		rigidbody.AddForce(Gravity*(movementSpeed/15), ForceMode.VelocityChange);
		rigidbody.position = new Vector3(
				Mathf.Clamp(rigidbody.position.x,boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp(rigidbody.position.z,boundary.zMin, boundary.zMax)
			 );
		rigidbody.rotation = Quaternion.Euler (0.0f, 95f - (rigidbody.velocity.z*(tilt-(movementSpeed/10))), 90f);
		myPosition = transform.position;
		Debug.Log (myPosition);
		//GameController.FlashText.transform.position = PlayerController.myPosition;

	}
	void OnTriggerEnter(Collider other)
	{
		count = count + 1;
		CountText.text = "Count: " + count.ToString();
	}

}
