using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snake : MonoBehaviour
{
	// private static instance of class
	private static Snake instance = null;
	// private fields
	private List<int> snakePosXIndex = new List<int>();
	private List<int> snakePosYIndex = new List<int>();
	private List<Texture2D> snakeIcon = new List<Texture2D>();
	private int snakeLength = 3;
	private float moveDelay;
	private AudioClip move1;
	private AudioClip move2;
	private AudioClip death;
	private bool addSquare;
	private bool canMove = true;
	public static int[] initXPos = new int[]
		{22,42,62,82,102,122,142,162,182,202,222,
		242,262,282,302,322,342,362,382,402,422,
		442,462,482,502,522,542,562,582,602,622,
		642,662,682,702,722,742,762,782,802,822,
		842,862,882,902,922,942,962,982};
	public static int[] initYPos = new int[]
		{94,114,134,154,174,194,214,234,254,274,
		294,314,334,354,374,394,414,434,454,474,
		494,514,534,554,574,594,614,634,654};
	public Direction lastDirectionIndicated = Direction.LEFT;
	
	// direction enum for clarification
	public enum Direction
	{
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public static Snake Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameObject("Snake").AddComponent<Snake>();
			}
			return instance;
		}
	}
	
	void OnApplicationQuit()
	{
		DestroyInstance();
	}

	void DestroyInstance()
	{
		print("Snake Instance destroyed");
		instance = null;
	}

	void OnGUI()
	{
		for (int i = 0; i < snakeLength; i++)
		{
			Rect tempPos = new Rect(initXPos[snakePosXIndex[i]], initYPos[snakePosYIndex[i]],
			                        initXPos[1] - initXPos[0], initYPos[1] - initYPos[0]);
			GUI.DrawTexture(tempPos, snakeIcon[i]);
		}
	}

	void Update()
	{
		if (canMove)
		{
			UpdateSnake();
		}
	}
	
	private void UpdateSnake()
	{
		if (InputHelper.GetStandardMoveMultiInputKeys())
		{
			//Debug.Log ("We are pressing multiple keys for direction");
			MoveSnake(lastDirectionIndicated);
		}
		else
		{
			// are we moving up
			if (InputHelper.GetStandardMoveUpDirection())
			{
				if (lastDirectionIndicated != Direction.DOWN)
				{
					lastDirectionIndicated = Direction.UP;
					MoveSnake(Direction.UP);
				}
				else
				{
					MoveSnake(lastDirectionIndicated);
				}
			}
			else
			{
				// are we moving left
				if (InputHelper.GetStandardMoveLeftDirection())
				{
					if (lastDirectionIndicated != Direction.RIGHT)
					{
						lastDirectionIndicated = Direction.LEFT;
						MoveSnake(Direction.LEFT);
					}
					else
					{
						MoveSnake(lastDirectionIndicated);
					}
				}
				else
				{
					// are we moving down
					if (InputHelper.GetStandardMoveDownDirection())
					{
						if (lastDirectionIndicated != Direction.UP)
						{
							lastDirectionIndicated = Direction.DOWN;
							MoveSnake(Direction.DOWN);
						}
						else
						{
							MoveSnake(lastDirectionIndicated);
						}
					}
					else
					{
						if (InputHelper.GetStandardMoveRightDirection())
						{
							if (lastDirectionIndicated != Direction.LEFT)
							{
								lastDirectionIndicated = Direction.RIGHT;
								MoveSnake(Direction.RIGHT);
							}
							else
							{
								MoveSnake(lastDirectionIndicated);
							}
						}
						else
						{
							MoveSnake(lastDirectionIndicated);
						}
					}
				}
			}
		}
		// here we check for snake collision with itself
		if (SnakeCollidedWithSelf() == true)
		{
			StartCoroutine(EndGame());
		}
		StartCoroutine(DelayGame());
	}
	
	private IEnumerator EndGame()
	{
		canMove = false;
		yield return new WaitForSeconds(moveDelay);
		KillSelf();
		canMove = true;
	}


	private IEnumerator DelayGame()
	{
		canMove = false;
		yield return new WaitForSeconds(moveDelay);
		canMove = true;
	}

	public void MoveSnake(Direction moveDirection)
	{
		// define a temp List of Rects to our current snakes List of Rects
		List<int> tempXIndices = new List<int>();
		List<int> tempYIndices = new List<int>();
		// initialize
		for (int i = 0; i < snakePosXIndex.Count; i++)
		{
			tempXIndices.Add(snakePosXIndex[i]);
			tempYIndices.Add(snakePosYIndex[i]);
		}
		switch (moveDirection)
		{
		case Direction.UP:
			if (CheckForValidUpMove())
			{
				// we can move up
				snakePosYIndex[0] = snakePosYIndex[0] - 1;
				// now update the rest of our body
				UpdateMovePosition(tempXIndices, tempYIndices);
				// check for food
				if (CheckForFood())
				{
					addSquare = true;
				}
				// toggle the audio clip and play
				audio.clip = (audio.clip == move1) ? move2 : move1;
				audio.Play();
			}
			else
			{
				StartCoroutine(EndGame());
			}
			break;
		case Direction.LEFT:
			if (CheckForValidLeftMove())
			{
				// we can move left
				snakePosXIndex[0] = snakePosXIndex[0] - 1;
				// now update the rest of our body
				UpdateMovePosition(tempXIndices, tempYIndices);
				// check for food
				if (CheckForFood())
				{
					addSquare = true;
				}
				// toggle the audio clip and play
				audio.clip = (audio.clip == move1) ? move2 : move1;
				audio.Play();
			}
			else
			{
				StartCoroutine(EndGame());
			}
			break;
		case Direction.DOWN:
			if (CheckForValidDownMove())
			{
				// we can move down
				snakePosYIndex[0] = snakePosYIndex[0] + 1;
				// now update the rest of our body
				UpdateMovePosition(tempXIndices, tempYIndices);
				// check for food
				if (CheckForFood())
				{
					addSquare = true;
				}
				// toggle the audio clip and play
				audio.clip = (audio.clip == move1) ? move2 : move1;
				audio.Play();
			}
			else
			{
				StartCoroutine(EndGame());
			}
			break;
		case Direction.RIGHT:
			if (CheckForValidRightMove())
			{
				// we can move right
				snakePosXIndex[0] = snakePosXIndex[0] + 1;
				// now update the rest of our body
				UpdateMovePosition(tempXIndices, tempYIndices);
				// check for food
				if (CheckForFood())
				{
					addSquare = true;
				}
				// toggle the audio clip and play
				audio.clip = (audio.clip == move1) ? move2 : move1;
				audio.Play();
			}
			else
			{
				StartCoroutine(EndGame());
			}
			break;
		}
	}
	
	private void KillSelf()
	{
		//Play death sound
		audio.clip = death;
		audio.Play();
		//Flash red
		StartCoroutine(ScreenHelper.FlashScreen(1, 0.15f, new Color(1, 0, 0, 0.5f)));
		//Reduce number of lives
		SnakeGame.Instance().UpdateLives(-1);
		RespawnSnake();
	}

	private void UpdateMovePosition(List<int> tmpX, List<int> tmpY)
	{
		// update our snakePos Rect with the tmpRect positions
		for (int i = 0; i < tmpX.Count - 1; i++)
		{
			// exe. size of 3, assign 1,2,3 to 0,1,2 - snakePos[0] is already assigned
			snakePosXIndex[i + 1] = tmpX[i];
			snakePosYIndex[i + 1] = tmpY[i];
		}
		if (addSquare)
		{
			snakeLength++;
			snakePosXIndex.Add(tmpX[tmpX.Count - 1]);
			snakePosYIndex.Add(tmpY[tmpY.Count - 1]);
			BuildSnakeSegment(tmpX[tmpX.Count - 1], tmpY[tmpY.Count - 1]);
			addSquare = false;
		}
	}
	
	private bool CheckForFood()
	{
		if (Food.Instance != null)
		{
			Rect[] foodRects = Food.Instance.foodPos.ToArray();
			char[] possibleChars = Food.Instance.letterList.ToArray();
			Rect tempSnakePos = new Rect(initXPos[snakePosXIndex[0]], initYPos[snakePosYIndex[0]],
			                             initXPos[1] - initXPos[0], initYPos[1] - initYPos[0]);
			for (int i = 0; i < foodRects.Length; i++)
			{
				if (tempSnakePos.Contains(new Vector2(foodRects[i].x, foodRects[i].y)))
				{
					// we re-position the food
					if (possibleChars[i] == possibleChars[0])
					{
						// we add to our score
						SnakeGame.Instance().UpdateScore(1);
						Food.Instance.RemoveLetter(i);
						if( moveDelay != .1f)
						{
							moveDelay -= .01f;
						}
						return true;
					}
					else
					{
						return false;
					}
				}
			}
		}
		return false;
	}

	private bool CheckForValidDownMove()
	{
		if (snakePosYIndex[0] != (initYPos.GetLength(0) - 1))
		{
			return true;
		}
		return false;
	}

	private bool CheckForValidUpMove()
	{
		if (snakePosYIndex[0] != 0)
		{
			return true;
		}
		return false;
	}

	private bool CheckForValidLeftMove()
	{
		if (snakePosXIndex[0] != 0)
		{
			return true;
		}
		return false;
	}

	private bool CheckForValidRightMove()
	{
		if (snakePosXIndex[0] != (initXPos.GetLength(0) - 1))
		{
			return true;
		}
		return false;
	}

	private void BuildSnakeSegment(Rect rctPos)
	{
		// define our snake head and tail texture
		snakeIcon.Add(TextureHelper.CreateTexture(20, 20, Color.green));
	}

	private void BuildSnakeSegment(int xIndx, int yIndx)
	{
		BuildSnakeSegment(new Rect(initXPos[xIndx], initYPos[yIndx], initXPos[1] - initXPos[0], initYPos[1] - initYPos[0]));
	}
	
	private bool SnakeCollidedWithSelf()
	{
		bool didCollide = false;
		if (snakePosXIndex.Count <= 4)
		{
			return false;
		}
		for (int i = 1; i < snakePosXIndex.Count; i++)
		{
			if (snakePosXIndex[0] == snakePosXIndex[snakePosXIndex.Count - i]
			    && snakePosYIndex[0] == snakePosYIndex[snakePosYIndex.Count - i])
			{
				// we have collided
				didCollide = true;
				break;
			}
		}
		return didCollide;
	}
	
	public void Initialize()
	{
		//print("Snake initialized");
		// clear our Lists
		snakePosXIndex.Clear();
		snakePosYIndex.Clear();
		snakeIcon.Clear();
		// initialize our length to start length
		snakeLength = 3;
		// intialize our moveDelay
		moveDelay = 0.15f;
		// add our AudioSource component
		if (!gameObject.GetComponent<AudioSource>())
		{
			// load in our clips
			move1 = Resources.Load("Sounds/Move1 Blip") as AudioClip;
			move2 = Resources.Load("Sounds/Move2 Blip") as AudioClip;
			death = Resources.Load("Sounds/Death") as AudioClip;
			gameObject.AddComponent<AudioSource>();
			// initialize some audio properties
			audio.playOnAwake = false;
			audio.loop = false;
			audio.clip = move1;
		}
		for (int i = 0; i < 3; i++)
		{
			// define our snake head and tail texture
			snakeIcon.Add(TextureHelper.CreateTexture(20, 20, Color.green));
			// define our snake head and tail GUI Rect
			snakePosXIndex.Add(23 + i);
			snakePosYIndex.Add(14);
		}
		// make sure our localScale is correct for a GUItexture
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.identity;
		transform.localScale = Vector3.one;
	}
	
	private void RespawnSnake()
	{
		snakePosXIndex.Clear();
		snakePosYIndex.Clear();
		snakeIcon.Clear();
		// initialize our length to start length
		snakeLength = 3;
		// intialize our moveDelay
		moveDelay = 0.15f;
		for (int i = 0; i < 3; i++)
		{
			// define our snake head and tail texture
			snakeIcon.Add(TextureHelper.CreateTexture(20, 20, Color.green));
			// define our snake head and tail GUI Rect
			snakePosXIndex.Add(23 + i);
			snakePosYIndex.Add(14);
		}
	}
}