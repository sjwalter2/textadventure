using UnityEngine;
using System.Collections;

public class PewPewCanvasMenu: MonoBehaviour {
	private GameObject menuvar;
	private bool menuon;

	// Use this for initialization
	void Start () {
		menuvar = GameObject.FindGameObjectsWithTag ("menu")[0];
		menuon = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (menuon) {
			menuvar.SetActive (true);
		} else {
			menuvar.SetActive (false);
		}

		if (Input.GetButton ("Cancel")) {
			menuon = !menuon;
		}
	
	}
}
