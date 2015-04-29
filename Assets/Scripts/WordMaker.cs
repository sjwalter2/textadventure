using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WordMaker : MonoBehaviour {
	public Text MachineText;
	WordPower[] otherwords;
	reader Reader;

	int index;
	int end;

	void Start(){
		DontDestroyOnLoad (MachineText);
		Reader = new reader ();
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

	public WordPower nextWord(){
		if (index == end) {
			WordPower error = new WordPower();
			error.setWord ("Error");
			return error;
		} else {
			otherwords[index].setType (Reader.getType(otherwords[index].getWord ()));
			index = index + 1;
			return otherwords[index - 1];
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
