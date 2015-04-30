using UnityEngine;
using System.Collections;

public class WordPower {

	string word;
	string type;
	
	public void setWord(string text){
		word = text;
	}

	public string getWord(){
		return word;
	}

	public void setType(string s){
		type = s;
	}

	public string getType(){
		return type;
	}
}
