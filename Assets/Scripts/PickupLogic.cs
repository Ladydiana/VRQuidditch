using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLogic : MonoBehaviour {

	public int value = 1;

	void OnTriggerEnter (Collider other) {
		Debug.Log ("Trigger collision detected");
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Pickup.");
			Destroy (gameObject);
		} 
		else {
			// we assume it was spawned somewhere inside the stadium prefab
			Destroy (gameObject);
		}
	}


}
