using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WordMaker : MonoBehaviour {
	public Text MachineText;
	string[] words;
	int index;
	int end;

	void Start(){
		DontDestroyOnLoad (MachineText);
	}

	public void read(){
		words = MachineText.text.Split (' ');
		index = 0;
		end = words.Length;
	}
	public string nextWord(){
		if (index == end) {
			return "3rr0r";
		} else {
			index = index + 1;
			return words [index - 1];
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
