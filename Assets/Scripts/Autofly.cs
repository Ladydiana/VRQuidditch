using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Autoflight script
 * Flies in the direction the player is facing with a given speed.
 */

public class Autofly : MonoBehaviour {

	public float speed = 50.0f;
	public bool flying = true;


	// Update is called once per frame
	void Update () {
		if (flying) {
			//transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
			transform.Translate (Camera.main.transform.forward * speed * Time.deltaTime);
			//transform.Translate(Camera.main.transform.forward * Time.deltaTime * speed, Space.World);
		}

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;


		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider.tag.Contains ("ArenaDelimiter")) { 
				if (hit.distance <= 16) {
					Debug.Log ("Hit");
					//gameObject.GetComponent<Rigidbody> ().velocity = Vector3.Reflect (gameObject.GetComponent<Rigidbody> ().velocity, hit.collider.gameObject.GetComponent<MeshFilter> ().mesh.normals[0]);
					//Rigidbody.AddForce(otherBall.Rigid_Body.velocity);
					if (hit.collider.GetComponent<Rigidbody> () != null) {
						hit.rigidbody.AddForce (Vector3.forward * 1000);
					}
					//gameObject.rigidbody.velocity * = -1;

					flying = false;
					Debug.Log ("flying=false");
					//gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.back * -8000);
					Debug.Log ("Knockback");
					//gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				} 
				else {
					flying = true;
				}
			} 
			else {
				flying = true;
			}
		} 
		else {
			flying = true;
		}
	}
}