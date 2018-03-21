using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Autoflight script
 * Walks in the direction the player is facing with a given speed.
 */

public class Autofly : MonoBehaviour {

	public float speed = 50.0f;
	public bool flying = true;


	// Update is called once per frame
	void Update () {
		if (flying) {
			//transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
			transform.Translate (Camera.main.transform.forward * speed * Time.deltaTime);
		}
	}

	void onTriggerEnter(Collider other) {
		if(other.gameObject.tag=="ArenaDelimiter") {
			Debug.Log ("Arena collision.");
		}
	}
}