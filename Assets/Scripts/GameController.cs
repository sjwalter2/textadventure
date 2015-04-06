using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public string enemy = "In Xanadu did khubilai khan a stately pleasure dome decree, where Alph, the sacred river ran " +
		"through caverns measureless to man down to a sunless sea";
	private string[] enemys;
	// Use this for initialization
	void Start () {
		enemys = enemy.Split();
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		int currentWord = 0;

		while (currentWord < enemys.GetLength (0)) {
			for (int i = 0; i<hazardCount; i++) {
				if(currentWord < enemys.GetLength(0)){
					Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotation = Quaternion.identity;
					GameObject thingy = (GameObject)Instantiate (hazard, spawnPosition, spawnRotation);
					Debug.Log (thingy.GetType());
					thingy.GetComponent<TextMesh>().text = enemys[currentWord];
					var a = thingy.collider.bounds;
					var b = thingy.renderer.bounds;
					thingy.GetComponent<BoxCollider>().size = b.size;
					thingy.GetComponent<BoxCollider>().center = Vector3.zero;
				}
				currentWord++;
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
		Debug.Log ("You Win or Something");
	}
}
