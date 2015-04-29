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
			//do something
		}
		index = index + 1;
		return words[index - 1];
	}
}
