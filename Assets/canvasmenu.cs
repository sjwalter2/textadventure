using UnityEngine;
using System.Collections;

public class canvasmenu : MonoBehaviour {
	private GameObject menuvar;

	// Use this for initialization
	void Start () {
		menuvar = GameObject.FindGameObjectsWithTag ("menu")[0];
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton ("Cancel")) {
			menuvar.SetActive(false);
		}
	
	}
}
