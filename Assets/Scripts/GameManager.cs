using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode {Static, Hoop, Snitch, FreeRoam, Survival};

public class GameManager : MonoBehaviour {

	public bool gameStarted = false;
	public GameMode gameMode = GameMode.Static;
	public static int score;
	private const string scoreText= "SCORE: "; 
	private GameObject scoreCanvas, mainMenuCanvas;
	private GameObject mainCamera, snitch, spawner;

	// Use this for initialization
	void Start () {
		gameStarted = false;
		score = 0;

		scoreCanvas = GameObject.FindGameObjectWithTag ("ScoreCanvas");
		mainMenuCanvas = GameObject.FindGameObjectWithTag ("MainMenuCanvas");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		snitch = GameObject.FindGameObjectWithTag ("Snitch");
		spawner = GameObject.FindGameObjectWithTag ("Spawner");

		gameStartedCheck ();

		checkModesCheck ();

		scoreCanvas.GetComponentInChildren<Text>().text = scoreText + score.ToString();
	}
		
	public void checkModesCheck() {
		// if not in Snitch Mode deactivate Snitch
		if (gameMode != GameMode.Snitch) {
			snitch.SetActive (false);
		}

		// if not in Hoop mode don't spawn hoops
		if (gameMode != GameMode.Hoop && gameMode != GameMode.Survival) {
			spawner.SetActive (false);
		}

		if (gameMode == GameMode.Hoop || gameMode == GameMode.Survival) {
			spawner.SetActive (true);
		}

		if (gameMode == GameMode.Snitch) {
			snitch.SetActive (true);
		}
	}

	public void gameStartedCheck() {
		//scoreCanvas = GameObject.FindGameObjectWithTag ("ScoreCanvas");
		//mainMenuCanvas = GameObject.FindGameObjectWithTag ("MainMenuCanvas");

		if (gameStarted == false) {
			scoreCanvas.SetActive (false);
			mainMenuCanvas.SetActive (true);
		} 
		else {
			scoreCanvas.SetActive (true);
			mainMenuCanvas.SetActive (false);
		}
	}

	public void incrementScore(int amount) {
		score+=amount;
		GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Text>().text = scoreText + score.ToString();
	}

	public void printScore() {
		Debug.Log("Score: " + score);
	}

	public void changeGameMode (string mode) {
		switch(mode.ToUpper()) {
		case "FREEROAM":
			Debug.Log ("Freeroam.");
			gameMode = GameMode.FreeRoam;
			gameStarted = true;
			break;
		case "SNITCH":
			Debug.Log ("Snitch");
			gameMode = GameMode.Snitch;
			gameStarted = true;
			break;
		case "HOOP":
			Debug.Log ("Hoop");
			gameMode = GameMode.Hoop;
			gameStarted = true;
			break;
		case "SURVIVAL":
			Debug.Log ("Survival");
			gameMode = GameMode.Survival;
			gameStarted = true;
			break;
		default:
			Debug.Log ("Static");
			gameMode = GameMode.Static;
			gameStarted = false;
			break;
		}

		gameStartedCheck ();
		checkModesCheck ();
		score = 0;

	}
}
