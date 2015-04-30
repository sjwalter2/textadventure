using UnityEngine;
using System.Collections;

public class PewPewEventManager : MonoBehaviour {

	public delegate void onDestroyAction(float speed);
	public static event onDestroyAction onDestroy;

	public delegate void onScoreAction(int update);
	public static event onScoreAction onScore;

	public delegate void onPauseAction();
	public static event onPauseAction onPause;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if(onDestroy != null) {
//			onDestroy();
//		}
	}

	public void boom (float speed) {
		//Debug.Log ("in boom the speed is " + speed);
		if(onDestroy != null) {
			onDestroy(speed);
		}
	}

	public void ding (int update) {
		if (onScore != null) {
			onScore(update);
		}
	}

	public void pause () {
		if (onPause != null) {
			onPause();
		}
	}
}
