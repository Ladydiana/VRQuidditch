using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLogic : MonoBehaviour {

	public int value = 1;
	public AudioClip destroyAudioSource;
	private GameManager gameManager;

	void Start() {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
	}

	void OnTriggerEnter (Collider other) {
		//Debug.Log ("Trigger collision detected");
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("Pickup.");

			if (destroyAudioSource != null) {
				AudioSource.PlayClipAtPoint (destroyAudioSource, transform.position);
			}

			//gameManager.incrementScore ();
			//gameManager.printScore ();

			// if survival mode increment score
			if (gameManager.gameMode == GameMode.Survival) {
				gameManager.incrementScore ();
				gameManager.printScore ();
			}

			Destroy (gameObject);
		} 
		else {
			// we assume it was spawned somewhere inside the stadium prefab
			Destroy (gameObject);
		}
	}


}
