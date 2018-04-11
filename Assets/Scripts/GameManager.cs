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
	private GameObject mainCamera;

	// Use this for initialization
	void Start () {
		gameStarted = false;
		score = 0;

		scoreCanvas = GameObject.FindGameObjectWithTag ("ScoreCanvas");
		mainMenuCanvas = GameObject.FindGameObjectWithTag ("MainMenuCanvas");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		gameStartedCheck ();

		checkModesCheck ();

		scoreCanvas.GetComponentInChildren<Text>().text = scoreText + score.ToString();
	}
		
	public void checkModesCheck() {
		// if not in Snitch Mode deactivate Snitch
		if (gameMode != GameMode.Snitch) {
			GameObject.FindGameObjectWithTag ("Snitch").SetActive (false);
		}

		// if not in Hoop mode don't spawn hoops
		if (gameMode != GameMode.Hoop && gameMode != GameMode.Survival) {
			GameObject.FindGameObjectWithTag ("Spawner").SetActive (false);
		}
	}

	public void gameStartedCheck() {
		scoreCanvas = GameObject.FindGameObjectWithTag ("ScoreCanvas");
		mainMenuCanvas = GameObject.FindGameObjectWithTag ("MainMenuCanvas");

		if (gameStarted == false) {
			scoreCanvas.SetActive (false);
			mainMenuCanvas.SetActive (true);
		} 
		else {
			scoreCanvas.SetActive (true);
			mainMenuCanvas.SetActive (false);
		}
	}

	public void incrementScore() {
		score++;
		GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<Text>().text = scoreText + score.ToString();
	}

	public void printScore() {
		Debug.Log("Score: " + score);
	}
}
