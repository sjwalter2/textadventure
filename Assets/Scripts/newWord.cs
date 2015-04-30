using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newWord : MonoBehaviour {

	public Text myText;
	public WordMaker myScript;

	void Start(){
		myScript = GameObject.Find ("MachineText").GetComponent <WordMaker>();
	}
	
	public void NextWord(){
		myText.text = myScript.nextWord ().getWord();
	}

}
