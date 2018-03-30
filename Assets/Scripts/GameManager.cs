using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {Hoop, Snitch, FreeRoam};

public class GameManager : MonoBehaviour {

	public bool gameStarted = false;
	public GameMode gameMode;

	// Use this for initialization
	void Start () {
		gameStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
