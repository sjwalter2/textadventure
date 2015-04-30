using UnityEngine;
using System.Collections;
/// <summary>
/// 2D Snake game built in Unity. Version 0.01
/// </summary>
public class GameManager : MonoBehaviour
{
	// public fields here

	// private fields here

	// ---------------------------------------------------------------------
	// Start()
	// ---------------------------------------------------------------------
	// Unity method, called at game start automatically
	// ---------------------------------------------------------------------
	void Start ()
	{
		// build our SnakeGame object
		SnakeGame.Instance().Initialize();

		// build our Food object
		Food.Instance.Initialize();

		// build our Snake object
		Snake.Instance.Initialize();
	}
}
