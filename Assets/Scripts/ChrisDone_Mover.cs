using UnityEngine;
using System.Collections;

public class ChrisDone_Mover : MonoBehaviour
{
	public float speed;
	public Vector3 Left;
	void Start ()
	{
		//Left = Left * (PlayerController.gameSpeed/5);
		rigidbody.AddForce(Left*(ChrisPlayerController.gameSpeed)/5, ForceMode.VelocityChange);
	}
}
