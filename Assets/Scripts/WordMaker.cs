using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WordMaker : MonoBehaviour {
	public Text MachineText;
	string[] words;
	int index;

	void Start(){
		DontDestroyOnLoad (MachineText);
	}

	public void read(){
		words = MachineText.text.Split (' ');
		index = 0;
	}
	public string nextWord(){
			index = index + 1;
			return words[index - 1];
	}
}
