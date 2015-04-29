using UnityEngine;
using System.Collections;

public class changeLevel : MonoBehaviour {

	public string levelName;

	public void Change(){
		Application.LoadLevel(levelName);
	}
}
