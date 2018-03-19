using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Autowalk script
 * Walks in the direction the player is facing with a given speed.
 * Stop when facing the ground.
 */

public class Autofly : MonoBehaviour {

	public GameObject ground;
	public float speed = 50.0f;
	public bool flying = true;


	// Update is called once per frame
	void Update () {
		if (flying) {
			transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
		}



		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			/*if (hit.collider.name.Contains (ground.name)) { //"Terrain"
				if (hit.distance <=5) {
					flying = false;
				}
			} else {
				flying = true;
			}*/
		} else {
			flying = true;
		}

	}
}