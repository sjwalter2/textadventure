using UnityEngine;
using System.Collections;

public class PewPewGameController : MonoBehaviour {

	private GameObject menuvar;
	public GameObject player;
	private bool menuon;
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public string enemy = "In Xanadu dskdfsfjk did khubilai khan a stately pleasure dome decree, where Alph, the sacred river ran " +
		"through caverns measureless to man down adfsujio asdfsdfdsq to a sunless sea";
	public PewPewPlayerControllerNew p;

	private string[] enemys;
	private bool gameover;
	private bool restart;
	private bool pausegeneration;

	public WordMaker myScript;

	// Use this for initialization
	void Start () {
		myScript = GameObject.Find ("MachineText").GetComponent <WordMaker>();
		enemys = enemy.Split();
		StartCoroutine (SpawnWaves ());
		gameover = false;
		restart = false;

		menuvar = GameObject.FindGameObjectsWithTag ("menu")[0];
		menuon = false;
		pausegeneration = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (menuon) {
			menuvar.SetActive (true);
		} else {
			menuvar.SetActive (false);
		}

		if (gameover && restart) {
			Application.LoadLevel (Application.loadedLevel);
		}	
	}

	void OnGUI () {
		Event e = Event.current;
		if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Escape) {
			pause();
			menuon = !menuon;
			Debug.Log ("menu event");
		}
	}

	void pause() {
		GameObject[] gg = GameObject.FindGameObjectsWithTag ("texteroid");
		foreach (GameObject g in gg) {
			PewPewBoltMover b = g.GetComponent<PewPewBoltMover>();
			b.paused = !b.paused;
		}

		GameObject[] bolt = GameObject.FindGameObjectsWithTag ("Projectile");
		foreach (GameObject b in bolt) {
			PewPewBoltMover bm = b.GetComponent <PewPewBoltMover>();
			bm.paused = !bm.paused;
		}
		pausegeneration = !pausegeneration;

	}

	IEnumerator SpawnWaves() {
		yield return new WaitForSeconds(startWait);
		int currentWord = 0;

		while (myScript.hasNextWord () && !gameover) {
			int i = 0;
			while (i < hazardCount && !gameover) {
				if(!pausegeneration) {
					if (myScript.hasNextWord ()) {
						string word = myScript.nextWord ().getWord ();
						int t = Random.Range(0,2);
						if (t == 0){
							spawnWordWithDupes (word);
						} else {
							spawnWord (word);
						}
					}
					//currentWord++;
					i++;
				} 
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
		Debug.Log ("You Win or Something");
		//GameObject.FindGameObjectWithTag ("menu").SetActive (true);
		menuon = true;
	}

	public void spawnWord(string word) {
		Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		GameObject thingy = (GameObject)Instantiate (hazard, spawnPosition, spawnRotation);
		Debug.Log (thingy.GetType ());
		thingy.GetComponent<TextMesh> ().text = word;
		
		var a = thingy.collider.bounds;
		var b = thingy.renderer.bounds;
		thingy.GetComponent<BoxCollider> ().size = b.size;
		thingy.GetComponent<BoxCollider> ().center = Vector3.zero;
		
		PewPewBoltMover bt = thingy.GetComponent<PewPewBoltMover> ();
		bt.dxn = "down";
	}

	public void spawnWordWithDupes(string word) {
		float xpos = Random.Range (-spawnValues.x, spawnValues.x);
		Vector3 spawnPosition = new Vector3 (xpos, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		GameObject thingy = (GameObject)Instantiate (hazard, spawnPosition, spawnRotation);
		Debug.Log (thingy.GetType ());
		thingy.GetComponent<TextMesh> ().text = word;
		
		var a = thingy.collider.bounds;
		var b = thingy.renderer.bounds;
		thingy.GetComponent<BoxCollider> ().size = b.size;
		thingy.GetComponent<BoxCollider> ().center = Vector3.zero;

		PewPewBoltMover bt = thingy.GetComponent<PewPewBoltMover> ();
		bt.dxn = "down";

		Vector3 rDupePosn = new Vector3 (xpos + b.extents.x + 1, spawnValues.y, spawnValues.z - 2);
		Quaternion rDupeRotn = Quaternion.identity;
		GameObject rDupe = (GameObject)Instantiate (hazard, rDupePosn, rDupeRotn);
		rDupe.GetComponent<TextMesh> ().text = getDupe ();
		rDupe.GetComponent<BoxCollider> ().size = rDupe.renderer.bounds.size;
		rDupe.GetComponent<BoxCollider> ().center = Vector3.zero;
		rDupe.transform.position = new Vector3 (rDupe.transform.position.x + rDupe.renderer.bounds.extents.x, rDupe.transform.position.y, rDupe.transform.position.z + 2);
		
		PewPewBoltMover rDupemv = rDupe.GetComponent<PewPewBoltMover> ();
		rDupemv.dxn = "down";
	}

	public string getDupe() {
		return "smang";
	}

	public void endgame() {
		gameover = true;
		Debug.Log ("Gameover");
	}

	public void restartme() {
		restart = true;
		Debug.Log ("restart");
	}

	public void resize(float size) {
		Debug.Log (size);
		int sz = (int)size;
		GameObject le = GameObject.FindGameObjectWithTag ("leftedge");
		GameObject re = GameObject.FindGameObjectWithTag ("rightedge");
		//destruct boundary
		GameObject bound = GameObject.FindGameObjectWithTag ("Boundary");
		//player position constraint boundary
		//GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (sz == 1) {
			Vector3 newPosl = new Vector3((float)-7.5, le.transform.position.y, le.transform.position.z);
			le.transform.position = newPosl;
			Vector3 newPosr = new Vector3((float)7.5, re.transform.position.y, re.transform.position.z);
			re.transform.position = newPosr;

			bound.transform.localScale =  new Vector3((float)15, bound.transform.localScale.y, bound.transform.localScale.z);
			p.xMin = (float)-6;
			p.xMax = (float)6;
			//b.xMin = (float)-6;
			//b.xMax = (float)6;
			// le.transform.position.Set ((float)-7.5, le.transform.position.y, le.transform.position.z);
			// re.transform.position.Set ((float)7.5, re.transform.position.y, re.transform.position.z);
		} else if (sz == 2) {
			Vector3 newPosl = new Vector3((float)-11.25, le.transform.position.y, le.transform.position.z);
			le.transform.position = newPosl;
			Vector3 newPosr = new Vector3((float)11.25, re.transform.position.y, re.transform.position.z);
			re.transform.position = newPosr;

			bound.transform.localScale =  new Vector3((float)22.5, bound.transform.localScale.y, bound.transform.localScale.z);
			p.xMin = (float)-10;
			p.xMax = (float)10;
			spawnValues.x = 10;
			//Boundary b = player.GetComponent<Boundary>();
			//b.xMin = (float)-10;
			//b.xMax = (float)10;
			// le.transform.position.Set ((float)-15, le.transform.position.y, le.transform.position.z);
			// re.transform.position.Set ((float)15, re.transform.position.y, re.transform.position.z);
		} else if (sz == 3) {
			Vector3 newPosl = new Vector3((float)-15, le.transform.position.y, le.transform.position.z);
			le.transform.position = newPosl;
			Vector3 newPosr = new Vector3((float)15, re.transform.position.y, re.transform.position.z);
			re.transform.position = newPosr;

			bound.transform.localScale =  new Vector3((float)30, bound.transform.localScale.y, bound.transform.localScale.z);
			p.xMin = (float)-13;
			p.xMax = (float)13;
			spawnValues.x = 13;
			//Boundary b = player.GetComponent<Boundary>();;
			//b.xMin = (float)-13;
			//b.xMax = (float)13;
			// le.transform.position.Set ((float)-22.5, le.transform.position.y, le.transform.position.z);
			// re.transform.position.Set ((float)22.5, re.transform.position.y, re.transform.position.z);
		} else {
		}
	}

	public void alterDirection(){
		Debug.Log ("swappa");
		/*
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Quaternion q = Quaternion.Euler (player.transform.rotation.x, (float)180, player.transform.rotation.z);
		player.transform.rotation = q;
		*/

		//player dxn
		if (p.dxn == "up") {
			p.dxn = "down";
		} else {
			p.dxn = "up";
		}

		//bolt and texteroid dxn
		GameObject[] gg = GameObject.FindGameObjectsWithTag ("texteroid");
		foreach (GameObject g in gg) {
			PewPewBoltMover b = g.GetComponent<PewPewBoltMover>();
			b.dxn = "down";
		}
	}
}
