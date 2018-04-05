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
		Debug.Log ("Trigger collision detected");
		if (other.gameObject.tag == "Player") {
			//Debug.Log ("Pickup.");

			if (destroyAudioSource != null) {
				AudioSource.PlayClipAtPoint (destroyAudioSource, transform.position);
			}

			if (gameManager.gameMode == GameMode.Survival) {
				gameManager.incrementScore ();
			}

			Destroy (gameObject);
		} 
		else {
			// we assume it was spawned somewhere inside the stadium prefab
			Destroy (gameObject);
		}
	}


}
