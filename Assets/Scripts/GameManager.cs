using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {Hoop, Snitch, FreeRoam, Survival};

public class GameManager : MonoBehaviour {

	public bool gameStarted = false;
	public GameMode gameMode = GameMode.FreeRoam;
	public static int score;

	// Use this for initialization
	void Start () {
		gameStarted = true;
		score = 0;

		// if not in Snitch Mode deactivate Snitch
		if (gameMode != GameMode.Snitch) {
			GameObject.FindGameObjectWithTag ("Snitch").SetActive (false);
		}

		// if not in Hoop mode don't spawn hoops
		if (gameMode != GameMode.Hoop && gameMode != GameMode.Survival) {
			GameObject.FindGameObjectWithTag ("Spawner").SetActive (false);
		}
	}
	
	public void incrementScore() {
		score++;
	}

	public void printScore() {
		Debug.Log("Score: " + score);
	}
}
