﻿using UnityEngine;
using System.Collections;

public class ChrisGameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	static public bool Starter;
	public TextMesh FlashText;
	public string enemy = "In Xanadu dskdfsfjk did khubilai khan a stately pleasure dome decree, where Alph, the sacred river ran " +
		"through caverns measureless to man down adfsujio asdfsdfdsq to a sunless sea";	
	private string[] enemies;
	public TextMesh words;
	public GameObject player;
	public float variation;

	public WordMaker myScript;


	void Start ()
	{
		myScript = GameObject.Find ("MachineText").GetComponent <WordMaker>();

		enemies = enemy.Split();
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		int x = 0;

		while (true)
		{
			x++;
			for (int i = 0; i < hazardCount; i++)
			{ 
				float y = Random.Range(1, 5);
				if (x%y == 0)spawnValues.z = Random.Range (spawnValues.z - variation, spawnValues.z + variation);
				if (spawnValues.z > 5) spawnValues.z = spawnValues.z-1;
				if (spawnValues.z < -5) spawnValues.z = spawnValues.z+1;
				
				Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				WordPower aWord = myScript.nextWord();
				hazard.GetComponentInChildren<TextMesh> ().text = aWord.getWord (); 
				hazard.GetComponentInChildren<BoxCollider> ().size = hazard.GetComponentInChildren<MeshRenderer>().bounds.size;
				hazard.GetComponentInChildren<BoxCollider> ().center = Vector3.zero;

				FlashText.GetComponent<TextMesh>().text = aWord.getWord ();
				FlashText.GetComponent<Transform>().position = player.GetComponent<Transform>().position;
				while (Starter == false){
					yield return new WaitForSeconds(0);
				}
				Starter = false;
				if (!myScript.hasNextWord()){
					myScript.restart ();
				}
			}
		}
	}
}