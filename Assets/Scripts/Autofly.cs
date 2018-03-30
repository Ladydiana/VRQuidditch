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
	private GameManager gameManager;
	private GameObject[] hoops;


	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		if (flying && (gameManager.gameMode == GameMode.FreeRoam ||
		    gameManager.gameMode == GameMode.Snitch)) {
			//transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
			transform.Translate (Camera.main.transform.forward * speed * Time.deltaTime);
			//transform.Translate(Camera.main.transform.forward * Time.deltaTime * speed, Space.World);
		} 
		else if (flying && (gameManager.gameMode == GameMode.Hoop)) {
			hoops = GameObject.FindGameObjectsWithTag ("MagicHoop");

			if (hoops.Length > 0) {
				transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(hoops[0].transform.position - transform.position), speed*Time.deltaTime);
				transform.position = Vector3.MoveTowards (transform.position, hoops[0].transform.position, speed * Time.deltaTime);
			}
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