using UnityEngine;
using System.Collections;

public class ChrisDone_DestroyByContact : MonoBehaviour
{
	public GUIText CountText;
	private int count;


	void OnTriggerEnter (Collider other)
	{	
		if (other.tag == "Player") Destroy (gameObject);
		if (other.tag == "Boundary") {

			ChrisPlayerController.count = -1;
		}
	}
}