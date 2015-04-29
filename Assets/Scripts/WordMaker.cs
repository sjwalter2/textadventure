using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WordMaker : MonoBehaviour {
	public Text MachineText;
	WordPower[] otherwords;

	int index;
	int end;

	void Start(){
		DontDestroyOnLoad (MachineText);
	}

	public void read(){
		string[] words = MachineText.text.Split (' ');
		otherwords = new WordPower[words.Length];
		for (int i = 0; i < words.Length; i++) {
			WordPower myWord = (WordPower) Instantiate(GetComponentInChildren<WordPower>());
			myWord.setWord(words[i]);
			otherwords[i] = myWord;
		}
		index = 0;
	}

	public string nextWord(){
		if (index == end) {
			//do something
		}
		index = index + 1;
		return otherwords[index - 1].getWord ();
	}
}
