using UnityEngine;
using System.Collections;

public class PewPewDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public GameObject bogeyExplosion;
	public string sentiment;
	private PewPewGameController gc;
	private PewPewEventManager em;

	// Use this for initialization
	void Start () {
		GameObject gco = GameObject.FindWithTag ("GameController");
		gc = gco.GetComponent <PewPewGameController> ();
		em = gco.GetComponent <PewPewEventManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag != "Boundary") {

			if (other.tag == "Player") {
				Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
				gc.endgame();
			} 
			if (tag == "texteroid") {
				Instantiate (explosion, transform.position, transform.rotation);
			} else if (tag == "bogey") {
				Instantiate (bogeyExplosion, transform.position, transform.rotation);
			}
			Debug.Log ("audio played");
			Destroy (other.gameObject);
			Destroy (gameObject);

//			GameObject g = GameObject.FindGameObjectsWithTag ("score")[0];
//			PewPewScoreScript s = g.GetComponent<PewPewScoreScript>();
//			s.score = s.score + 10;

			Debug.Log("sentiment is " + sentiment);

			int sentimentSpeedModifier = 1;
			if (sentiment == "good") {
				em.ding (100);
				sentimentSpeedModifier = 10;
			} else if (sentiment == "bad") {
				em.ding (5);
				sentimentSpeedModifier = -10;
			} else {
				em.ding(10);
			}

			float speed = gc.texteroidSpeed;

			if(this.tag == "texteroid") {
				speed = Mathf.Clamp (gc.texteroidSpeed + (float).1*sentimentSpeedModifier, (float)2.5, (float)10);
			} else if (this.tag == "bogey") {
				speed = Mathf.Clamp (gc.texteroidSpeed - (float).5*sentimentSpeedModifier, (float)2.5, (float)10);
			}
			//Debug.Log (speed);
			gc.texteroidSpeed = speed;
			em.boom (speed);
		} else {
//			float speed = Mathf.Clamp (gc.texteroidSpeed + (float).05, (float)2, (float)10);
//			gc.texteroidSpeed = speed;
//			em.boom (speed);
		}
	}
}
