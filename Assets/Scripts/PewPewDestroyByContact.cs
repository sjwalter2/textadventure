﻿using UnityEngine;
using System.Collections;

public class PewPewDestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
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

			float speed = gc.texteroidSpeed;

			if(this.tag == "texteroid") {
				speed = Mathf.Clamp (gc.texteroidSpeed + (float).1, (float)2.5, (float)10);
			} else if (this.tag == "bogey") {
				speed = Mathf.Clamp (gc.texteroidSpeed - (float).5, (float)2.5, (float)10);
			}
			gc.texteroidSpeed = speed;
			em.boom (speed);
		} else {
//			float speed = Mathf.Clamp (gc.texteroidSpeed + (float).05, (float)2, (float)10);
//			gc.texteroidSpeed = speed;
//			em.boom (speed);
		}
	}
}
