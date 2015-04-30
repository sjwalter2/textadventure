using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PewPewScoreScript : MonoBehaviour {
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
	
	}

	void OnEnable () {
		PewPewEventManager.onScore += UpdateScore;
	}
	
	void OnDisable () {
		PewPewEventManager.onScore -= UpdateScore;
	}

	void UpdateScore (int update) {
		score = score + update;
		Text t = GetComponent<Text> ();
		//Debug.Log ("yarp" + t.text);
		t.text = "score: " + score;
	}
}
