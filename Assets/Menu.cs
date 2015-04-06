using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Texture2D background;
	private bool clicked = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	private void OnGUI() {
		if (clicked) {
			GUI.DrawTexture (new Rect ((Screen.width / 2) - 100, 30, 200, 200), background);
		} else {
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Cancel")) {
			clicked = !clicked;
			Debug.Log ("menu");
		}
	}
}