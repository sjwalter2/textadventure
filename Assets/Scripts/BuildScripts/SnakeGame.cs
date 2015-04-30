using UnityEngine;
using System.Collections;
public class SnakeGame : MonoBehaviour
{
	// private fields
	private static SnakeGame instance = null;
	private string spellingWord = "";
	//private GameGUI displayGUI;
	private GUIText displayLives;
	private GUIText displayScore;
	private GUIText wordToSpell;
	// fields
	public int gameScore = 0;
	public int gameLives = 3;
	public int scoreMultiplier = 100;

	// ---------------------------------------------------------------------------------------------------
	// Instance()
	// ---------------------------------------------------------------------------------------------------
	// Creates an instance of ScreenField if one does not exists
	// ---------------------------------------------------------------------------------------------------
	public static SnakeGame Instance()
	{
		if (instance == null)
		{
			instance = new GameObject("SnakeGame").AddComponent<SnakeGame>();
		}
		return instance;
	
	}

	// ---------------------------------------------------------------------------------------------------
	// OnApplicationQuit()
	// ---------------------------------------------------------------------------------------------------
	// Called when you quit the application or stop the editor player
	// ---------------------------------------------------------------------------------------------------
	public void OnApplicationQuit()
	{
		DestroyInstance();
	}

	// ---------------------------------------------------------------------------------------------------
	// GetSpellingWord()
	// ---------------------------------------------------------------------------------------------------
	// 
	// ---------------------------------------------------------------------------------------------------
	public string GetSpellingWord()
	{
		return spellingWord;
	}

	// ---------------------------------------------------------------------------------------------------
	// DestroyInstance()
	// ---------------------------------------------------------------------------------------------------
	// Destroys the ScreenField instance
	// ---------------------------------------------------------------------------------------------------
	public void DestroyInstance()
	{
		print("Snake Game Instance destroyed");
		instance = null;
	}
	// ---------------------------------------------------------------------------------------------------
	// UpdateScore()
	// ---------------------------------------------------------------------------------------------------
	// Updates the game score, and the Score GUIText text display
	// ---------------------------------------------------------------------------------------------------
	public void UpdateScore(int additive)
	{
		// add to our current game score
		gameScore += additive * scoreMultiplier;
		// update our display
		displayScore.text = "Score: " + gameScore.ToString();
	}

	// ---------------------------------------------------------------------------------------------------
	// UpdateLives()
	// ---------------------------------------------------------------------------------------------------
	// Updates the snakes lives, and the Lives GUIText text display
	// ---------------------------------------------------------------------------------------------------
	public void UpdateLives(int additive)
	{
		// add to our current game score
		gameLives += additive;
		// clamp to o if lower
		gameLives = Mathf.Clamp(gameLives, 0, 3);
		// update our display
		displayLives.text = "Lives: " + gameLives.ToString();

		// check for playable lives left
		if (gameLives == 0)
		{
			// reload the level, resetting the game
			Application.LoadLevel("scene");
		}
		else
		{
			// here we handle resetting the snake after a collision
			Snake.Instance.Initialize();
			Snake.Instance.lastDirectionIndicated = Snake.Direction.LEFT;
		}
	}

	// ---------------------------------------------------------------------------------------------------
	// UpdateWord()
	// ---------------------------------------------------------------------------------------------------
	// Changes visual prompt of the word if it exists( dependant on difficulty), and gives audio prompt
	// ---------------------------------------------------------------------------------------------------
	public void UpdateWord()
	{
		spellingWord = "FOOD";
		wordToSpell.text = spellingWord;
		Food.Instance.UpdateFood(spellingWord);
	}

	// ---------------------------------------------------------------------------------------------------
	// Initialize()
	// ---------------------------------------------------------------------------------------------------
	// Initializes SnakeGame
	// ---------------------------------------------------------------------------------------------------
	public void Initialize()
	{
		print("SnakeGame initialized");
		// initialize transform information
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector3.one;
		// initialize SnakeGame variables
		gameScore = 0; // no score initially
		gameLives = 3; // 3 lives to start with
		scoreMultiplier = 100; // adjusts score display
		// setup our snake game border background
		GUIHelper.CreateGUITexture(new Rect(0,0,1024,768), Color.grey, "ScreenBorder", 0);
		// setup our snake game playing field
		GUIHelper.CreateGetGUITexture(new Rect(Snake.initXPos[0], Snake.initYPos[0],
	                            (Snake.initXPos[1] - Snake.initXPos[0])*Snake.initXPos.GetLength(0),
		                        (Snake.initYPos[1] - Snake.initYPos[0])*Snake.initYPos.GetLength(0)),
		                TextureHelper.LoadBackgroundTexture(), "ScreenField", 1);
//		GUIHelper.CreateGUITexture(new Rect( Snake.initXPos[0], Snake.initYPos[0],
//		                                    (Snake.initXPos[1] - Snake.initXPos[0])*Snake.initXPos.GetLength(0),
//		                                    (Snake.initYPos[1] - Snake.initYPos[0])*Snake.initYPos.GetLength(0))
//		                           , Color.black, "ScreenField", 1);
		// create and initialize our score GUIText
		displayScore = GUIHelper.CreateGetGUIText(new Vector2(10,758), "Game Score", "Score", 1);
		// update our integer score and display score
		UpdateScore(0);
		// create and initialize our lives GUIText
		displayLives = GUIHelper.CreateGetGUIText(new Vector2(944,758), "Game Lives", "Lives", 1);
		// update our integer lives and display lives
		UpdateLives(0);
		wordToSpell = GUIHelper.CreateGetGUIText(new Vector2(100, 758), "Word To Spell", spellingWord, 1);
		// update our word to spell
		UpdateWord();
	}
}