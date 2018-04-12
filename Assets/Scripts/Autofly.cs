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
	public bool looksAtHoop = false;


	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {

		Ray ray = Camera.main.ViewportPointToRay (new Vector3 (.5f, .5f, 0));
		RaycastHit hit;

		if (gameManager.gameStarted == false) {
			flying = false;
		} 
		else {
			flying = true;
		}

		//Debug.Log (flying);
		//Debug.Log (gameManager.gameMode);

		/*
		 * 	STATIC MODE
		 * - don't move -
		 */
		if (gameManager.gameMode == GameMode.Static || gameManager.gameStarted == false) {
			//do nothing
		}

		/*
		 * 	FREEROAM MODE or SNITCH MODE
		 * - free flying - 
		 */
		else if (flying && (gameManager.gameMode == GameMode.FreeRoam ||
		    gameManager.gameMode == GameMode.Snitch)) {
			transform.Translate (Camera.main.transform.forward * speed * Time.deltaTime);
		} 

		/*
		 * HOOP MODE
		 * - automated move to the next hoop - 
		 */
		else if (flying && (gameManager.gameMode == GameMode.Hoop)) {
			//Debug.Log (flying);
			//Debug.Log (gameManager.gameMode);

			//UnityEngine.XR.XRDevice.DisableAutoXRCameraTracking (GetComponent<Camera>(), true);

			hoops = GameObject.FindGameObjectsWithTag ("MagicHoop");

			//change rotation towards the next hoop if it exists
			if (hoops.Length > 0) {
				if (!(Quaternion.LookRotation (hoops [0].transform.position - transform.position).eulerAngles.Equals (Vector3.zero)) && !looksAtHoop) {
					transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (hoops [0].transform.position - transform.position), Time.deltaTime * 4);
				} 
			} 
			//else move forward
			else {
				transform.Translate (Camera.main.transform.forward * speed * Time.deltaTime);
			}
		}


		/*
		 * COLLISIONS
		 * - with hoops or walls -
		 */ 

		if (Physics.Raycast (ray, out hit)) {

			if (hit.collider.tag.Contains ("MagicHoop")) {
				looksAtHoop = true;
			}

			// Collisions with walls tagged Arena Delimiter
			if (hit.collider.tag.Contains ("ArenaDelimiter") && (gameManager.gameMode != GameMode.Hoop)) { 
				if (hit.distance <= 16) {
					Debug.Log ("Hit");
					if (hit.collider.GetComponent<Rigidbody> () != null) {
						hit.rigidbody.AddForce (Vector3.forward * 1000);
					}
					flying = false;
				} else {
					flying = true;
				}
			} 
			// Ray collisions with hoops
			// HOOP MODE part 2 -> translation

			else if (looksAtHoop==true && (gameManager.gameMode == GameMode.Hoop) && hoops.Length > 0) {
				transform.position = Vector3.MoveTowards (transform.position, hoops [0].transform.position, speed * Time.deltaTime);
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