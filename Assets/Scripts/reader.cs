using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;


public class reader {

	Hashtable Words;

	public reader(){
		Words = new Hashtable ();
		TextAsset goodFile = (TextAsset)Resources.Load ("positive-words", typeof(TextAsset));
		TextAsset badFile = (TextAsset)Resources.Load ("negative-words", typeof(TextAsset));
		StringReader lineReader = new StringReader(goodFile.text);
		if ( lineReader == null )
		{
			Debug.Log("File not found or not readable");
		}
		else
		{
			string nextString;
			// Read each line from the file
			while ( (nextString = lineReader.ReadLine()) != null )
				if(!Words.ContainsKey(nextString))
					Words.Add (nextString, "good");
		}
		lineReader = new StringReader (badFile.text);
		if ( lineReader == null )
		{
			Debug.Log("File not found or not readable");
		}
		else
		{
			string nextString;
			// Read each line from the file
			while ( (nextString = lineReader.ReadLine()) != null )
				if(!Words.ContainsKey (nextString))
					Words.Add (nextString, "bad");
		}
	}

	public string getType(string s){
		if(Words.ContainsKey(s)){
			return (string) Words[s];
		}
		else {return "neutral";}
	}
	
}
