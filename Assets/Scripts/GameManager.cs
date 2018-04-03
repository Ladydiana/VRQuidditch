using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {Hoop, Snitch, FreeRoam};

public class GameManager : MonoBehaviour {

	public bool gameStarted = false;
	public GameMode gameMode = GameMode.FreeRoam;

	// Use this for initialization
	void Start () {
		gameStarted = true;

		// if not in Snitch Mode deactivate Snitch
		if (gameMode != GameMode.Snitch) {
			GameObject.FindGameObjectWithTag ("Snitch").SetActive (false);
		}

		// if not in Hoop mode don't spawn hoops
		if (gameMode != GameMode.Hoop) {
			GameObject.FindGameObjectWithTag ("Spawner").SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
