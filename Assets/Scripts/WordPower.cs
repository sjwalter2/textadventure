using UnityEngine;
using System.Collections;

public class WordPower : MonoBehaviour {

	public GameObject myWord;
	string word;
	string type;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (myWord);
	}
	
	public void setWord(string text){
		word = text;
		type = "normal"; //at this point, search through list of words to set actual type
	}
	public string getWord(){
		return word;
	}

	public string getType(){
		return type;
	}
}
