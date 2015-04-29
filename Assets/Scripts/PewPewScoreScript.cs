using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PewPewScoreScript : MonoBehaviour {
	public int score;

	// Use this for initialization
	void Start () {
		score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		Text t = GetComponent<Text> ();
		Debug.Log ("yarp" + t.text);
		t.text = "score: " + score;
	}
}
