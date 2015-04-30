using UnityEngine;
using System.Collections;

public class ChrisGameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	static public bool Starter = true;
	public TextMesh FlashText;
	public string enemy3 = "1 22 333 4444 55555 666666 7777777 88888888 999999999 a bb ccc Dddd eeeee fffFf gggggg hhhhhhh";	
	private string[] enemies2;
	public TextMesh words;
	public GameObject player;
	public float variation;
	public  TextMesh textmesh;
	public WordMaker myScript;
	void Start ()
	{
		myScript = GameObject.Find ("MachineText").GetComponent <WordMaker>();
		enemies2 = enemy3.Split();
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		int x = 0;
		int currentWord = 0;
		int max = enemies2.GetLength (0);
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
				hazard.GetComponentInChildren<TextMesh> ().text = aWord.getWord();
				hazard.GetComponentInChildren<BoxCollider> ().size = hazard.GetComponentInChildren<MeshRenderer>().bounds.size;
				hazard.GetComponentInChildren<BoxCollider> ().center = new Vector3(0 - hazard.GetComponentInChildren<MeshRenderer>().bounds.size.x, 0, 0);

				FlashText.GetComponent<TextMesh>().text = aWord.getWord();;
				FlashText.GetComponent<Transform>().position = player.GetComponent<Transform>().position;

				hazard.GetComponentInChildren<TextMesh> ().color = Color.white;
				FlashText.GetComponentInChildren<TextMesh> ().color = Color.white;
				foreach (char c in aWord.getWord()){
					if (char.IsUpper(c)) {
						hazard.GetComponentInChildren<TextMesh> ().color = Color.magenta;
						FlashText.GetComponentInChildren<TextMesh> ().color = Color.magenta;
					}
				}

				float textX = hazard.GetComponentInChildren<MeshRenderer>().bounds.size.x;
				float timeWait = ((textX/(ChrisPlayerController.gameSpeed*1.67f))+(.3f/(ChrisPlayerController.gameSpeed*1.67f)));
				yield return new WaitForSeconds(timeWait);
				currentWord++;
				if (!myScript.hasNextWord()){
					myScript.restart ();
				}
			}
		}
	}
}