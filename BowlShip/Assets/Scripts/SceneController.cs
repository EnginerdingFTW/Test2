﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Scene controller. This Script should never be destroyed the entirety of the game. Serves as a core options menu with things such as 
/// Music and SFX volume, Number of Players, controls, etc.
/// </summary>
public class SceneController : MonoBehaviour {

	public int numPlayers = 8;									//The current number of players playing
	public int numAI = 0;										//The current number of players that are AI
	public int musicLevel = 100;								//The volume level of the music (0 - 100)
	public int SFXLevel = 50;									//The volume level of the Sound fx (0 - 100)
	public GameObject[] playerShips;							//An array of the ships that the players have selected to use
	public int[] playerNumArray;								//An array of PlayerNums that correspond to the playerShips array
	public int menuLevel = 0;									//which area of the menu to load to when booting up the menu 0 = help, 1 = main, 2 = gamemode, 3 = stage

	public int gameMode = 0;									//A int corresponding to which gamemode is chosen
	public int score = 1;										//A variable used to transfer a generic maxScore value to a specific gameMode

	public GameObject help;										//the help menu
	public GameObject main;										//the main menu
	public GameObject gamemodeSelect;							//the gamemode selection menu
	public GameObject stageSelect;								//the stage selection menu
	public GameObject menuHandler;								//the menu handler to instantiate players again

	/// <summary>
	/// Upon loading the application. This Scene Controller is never destroyed. This way the number of players, options settings, etc are consistent throughout multiple scenes.
	/// </summary>
	void Awake () {
		DontDestroyOnLoad (this);
		GameObject[] others = GameObject.FindGameObjectsWithTag ("SceneController");
		if (others.Length > 1 && menuLevel == 0) {
			Destroy (this.gameObject);
		}
//		playerNumArray = new int[8];
	}

	/// <summary>
	/// Sets the correct menu upon reloading.
	/// </summary>
	public void SetMenu() {
		switch (menuLevel) {
		case 1:
			help.SetActive (false);
			main.SetActive (true);
			gamemodeSelect.SetActive (false);
			stageSelect.SetActive (false);
			break;
		case 2:
			help.SetActive (false);
			main.SetActive (false);
			gamemodeSelect.SetActive (true);
			stageSelect.SetActive (false);
			menuHandler.GetComponent<MenuHandler> ().InstantiatePlayers ();
			break;
		case 3:
			help.SetActive (false);
			main.SetActive (false);
			gamemodeSelect.SetActive (false);
			stageSelect.SetActive (true);
			menuHandler.GetComponent<MenuHandler> ().InstantiatePlayers ();
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// The setter method for music volume in pause/options menu
	/// </summary>
	/// <param name="musicLevel">Music level.</param>
	public void setMusicLevel (int musicLevel) {
		this.musicLevel = musicLevel;
	}

	/// <summary>
	/// The setter method for SFX volume in pause/options menu
	/// </summary>
	/// <param name="sfx">Sfx.</param>
	public void setSFXLevel (int sfx) {
		SFXLevel = sfx;
	}

	/// <summary>
	/// The setter method for the number of players playing
	/// </summary>
	/// <param name="num">Number.</param>
	public void setNumPlayers (int num) {
		numPlayers = num;
	}

	/// <summary>
	/// The setter method for a players selected ship after he's selected
	/// </summary>
	/// <param name="playerNum">Player number.</param>
	/// <param name="ship">Ship.</param>
	public void selectShip (int playerNum, GameObject ship) {
		playerShips [playerNum] = ship;
	}

	/// <summary>
	/// Setter method for the maxScore needed in the next gameMode.
	/// </summary>
	/// <param name="score">Score.</param>
	public void setScore (int score) {
		this.score = score;
	}
}
