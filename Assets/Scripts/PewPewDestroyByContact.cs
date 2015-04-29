using UnityEngine;
using System.Collections;

public class PewPewDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	private PewPewGameController gc;
	// Use this for initialization
	void Start () {
		GameObject gco = GameObject.FindWithTag ("GameController");
		gc = gco.GetComponent <PewPewGameController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Boundary") {

			if(other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gc.endgame();
			}
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
			GameObject g = GameObject.FindGameObjectsWithTag ("score")[0];
			PewPewScoreScript s = g.GetComponent<PewPewScoreScript>();
			s.score = s.score + 10;
		}
	}
}
