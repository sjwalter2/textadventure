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

	string[] fakelist;

	void Start(){
		DontDestroyOnLoad (MachineText);
		Reader = new reader ();
		string s = "Gablrdarbl yelth lorem xXjxidF bbbzrrrttt kamblum vartlesnort xmek imjlxorp hantlok pharpl nonzhalant mesthlopotamia beepbeep oopboop garmophobia popuklumph pnjul rerejbo zoincn plheu qqeipz ppdliz dnfagu l9djp #$S$*GB 14482 1337 Y&#*K ELLO CRLF ((#))%%";
		fakelist = s.Split (' ');
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

	public void restart(){
		index = 0;
	}

	public string getFakeWord(){
		int num = (int)Random.Range (0, fakelist.Length);
		return fakelist[num];
	}

	public bool hasNextWord(){
		if (index >= end) {
			return false;
		} else {
			return true;
		}
	}
}
