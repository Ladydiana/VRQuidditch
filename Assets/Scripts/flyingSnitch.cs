using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingSnitch : MonoBehaviour {

	public GameObject[] checkpointPoints;
	public float snitchSpeed = 10f;
	private GameManager gameManager;
	private short lastCheckpoint;
	private short nextCheckpoint;

	// Use this for initialization
	void Start () {
		if (checkpointPoints!=null && checkpointPoints.Length > 0) {
			transform.position = checkpointPoints [0].transform.position;
		}

		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
		lastCheckpoint = 0;
		nextCheckpoint = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// Snitch movement
		if (gameManager.gameMode == GameMode.Snitch && gameManager.gameStarted) {
			if (transform.position == checkpointPoints [nextCheckpoint].transform.position) {
				nextCheckpoint++;
				lastCheckpoint++;
			}

			if (nextCheckpoint >= checkpointPoints.Length) {
				nextCheckpoint = 0;
			}

			if (lastCheckpoint >= checkpointPoints.Length) {
				lastCheckpoint = 0;
			}

			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (checkpointPoints [nextCheckpoint].transform.position - transform.position), snitchSpeed * Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, checkpointPoints [nextCheckpoint].transform.position, snitchSpeed * Time.deltaTime);
		}
	}

	public void catchSnitch() {
		Debug.Log ("Got the snitch!");
		gameManager.incrementScore (150);
		gameManager.printScore ();

		Destroy (gameObject);
	}

}
