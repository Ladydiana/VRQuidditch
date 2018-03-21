using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode {Hoop, Snitch, Simple};

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
