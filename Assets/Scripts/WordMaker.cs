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
			WordPower myWord = new WordPower();
			myWord.setWord(words[i]);
			otherwords[i] = myWord;
		}
		index = 0;
		end = otherwords.Length;
	}

	public string nextWord(){
		if (index == end) {
			return "3rr0r";
		} else {
			index = index + 1;
			return otherwords [index - 1].getWord();
		}
	}

	public bool hasNextWord(){
		if (index >= end) {
			return false;
		} else {
			return true;
		}
	}
}
