using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Food : MonoBehaviour {
	// public fields
	public List<Rect> foodPos = new List<Rect>();
	public List<Texture2D> foodTexture = new List<Texture2D>();
	public List<char> letterList = new List<char>();
	// private fields
	private static string spellingWord;
	private static SnakeGame gameInstance;
	private static Food instance = null;
	private static int[] initXPos = new int[] {22,42,62,82,102,122,142,162,182,202,222,242,262,282,302,322,342,362,
		382,402,422,442,462,482,502,522,542,562,582,602,622,642,662,682,702,
		722,742,762,782,802,822,842,862,882,902,922,942,962,982};
	private static int[] initYPos = new int[] {94,114,134,154,174,194,214,234,254,274,294,314,334,354,374,394,414,
		434,454,474,494,514,534,554,574,594,614,634,654};
	private AudioClip foodPickup;
	
	// ---------------------------------------------------------------------------------------------------
	// constructor field: Instance
	// ---------------------------------------------------------------------------------------------------
	// Creates an instance of Food if one does not exists
	// ---------------------------------------------------------------------------------------------------
	public static Food Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("Food").AddComponent<Food>();
			}
			return instance;
		}
	}
	// ---------------------------------------------------------------------------------------------------
	// Unity method: OnApplicationQuit()
	// ---------------------------------------------------------------------------------------------------
	// Called when you quit the application or stop the editor player
	// ---------------------------------------------------------------------------------------------------
	public void OnApplicationQuit()
	{
		DestroyInstance();
	}
	public void RemoveLetter(int i)
	{
		foodPos.RemoveAt(i);
		foodTexture.RemoveAt(i);
		letterList.RemoveAt(i);
		audio.Play();
		if(letterList.ToArray().GetLength(0) == 0)
		{
			gameInstance.UpdateWord();
		}
	}
	// ---------------------------------------------------------------------------------------------------
	// DestroyInstance()
	// ---------------------------------------------------------------------------------------------------
	// Destroys the Food instance
	// ---------------------------------------------------------------------------------------------------
	public void DestroyInstance()
	{
		print("Food Instance destroyed");
		instance = null;
	}
	// ---------------------------------------------------------------------------------------------------
	// UpdateFood()
	// --------------------------------------------------------------------------------------------------- 
	// Updates the Food position
	// ---------------------------------------------------------------------------------------------------
	public void UpdateFood( string spellingWord)
	{
		char[] charArray = spellingWord.ToCharArray();
		for( int i = 0; i < spellingWord.Length; i++)
		{
			int ranX;
			int ranY;
			do
			{
				ranX = Random.Range(0, initXPos.Length);
				ranY = Random.Range(0, initYPos.Length);
			}
			while (foodPos.Contains( new Rect( initXPos[ranX], initYPos[ranY], 20, 20)));
			// assign a random position to the pixelInset
			foodPos.Add( new Rect( initXPos[ranX], initYPos[ranY], 20, 20));
			foodTexture.Add( TextureHelper.CreateLetterTexture( 20, 20, charArray[i]));
			letterList.Add( charArray[i]);
		}
		print("Food updated");
		// initialize pixelInset random positions
	}
	// ---------------------------------------------------------------------------------------------------
	// OnGUI()
	// ---------------------------------------------------------------------------------------------------
	// Unity method for handling GUI rendering, used for rendering the Food texture
	// ---------------------------------------------------------------------------------------------------
	void OnGUI()
	{
		if (Food.Instance != null)
		{
			Rect[] tempPos = foodPos.ToArray();
			Texture2D[] tempTexture = foodTexture.ToArray();
			for(int i = 0; i < tempPos.GetLength(0); i++)
			{
				GUI.DrawTexture(tempPos[i], tempTexture[i]);
			}
		}
	}
	// ---------------------------------------------------------------------------------------------------
	// Initialize()
	// ---------------------------------------------------------------------------------------------------
	// Initializes Food
	// ---------------------------------------------------------------------------------------------------
	public void Initialize()
	{
		print("Food initialized");
		gameInstance = SnakeGame.Instance;
		// add our AudioSource component
		if (!gameObject.GetComponent<AudioSource>())
		{
			// load in our clips
			foodPickup = Resources.Load("Sounds/Food Pickup") as AudioClip;
			gameObject.AddComponent<AudioSource>();
			// initialize some audio properties
			audio.playOnAwake = false;
			audio.loop = false;
			audio.clip = foodPickup;
		}
		//gameInstance = game;
		// make sure our localScale is correct for a GUItexture
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector3.one;
	}
//
//	public void updateFoodTexture()
//	{
//		foodTexture = TextureHelper;
//	}
}