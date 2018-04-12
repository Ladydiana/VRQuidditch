using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/* Description: Spawns a given prefab.
 * Run Type: continuous
 * Location: Random location between (x +- deltaX, y +- deltaY, z +- deltaZ )
 */


public class SpawnGameObjects : MonoBehaviour {

	public GameObject spawnPrefab;
	public GameObject[] spawnPoints;


	public float deltaX = 0;
	public float deltaY = 0;
	public float deltaZ = 0;

	private GameManager gameManager;
	private GameObject mainCamera;
	private short nextSpawn;
	private GameObject player;
	private Autofly autofly;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager> ();
		nextSpawn = 1;
		player = GameObject.FindGameObjectWithTag ("Player");
		autofly = GameObject.FindObjectOfType(typeof(Autofly)) as Autofly;
    }
	
	// Update is called once per frame
	void Update () {
		if (gameManager.gameMode == GameMode.FreeRoam || gameManager.gameMode == GameMode.Survival) {
			if (GameObject.FindGameObjectWithTag ("MagicHoop") == false) {
				MakeThingToSpawnRandom ();
			}	
		}

		if (gameManager.gameMode == GameMode.Hoop) {
			if (GameObject.FindGameObjectWithTag ("MagicHoop") == false) {
				MakeThingToSpawnAtPos (spawnPoints[nextSpawn].transform.position);
				nextSpawn++;
				if (nextSpawn >= spawnPoints.Length) {
					nextSpawn = 0;
				}
			}
		}
	}

	void MakeThingToSpawnRandom() {
        if (gameManager.gameStarted) {
            // create spawn position
            Vector3 spawnPos = new Vector3(	Random.Range(transform.position.x - deltaX, transform.position.x + deltaX),
											Random.Range(transform.position.y - deltaY, transform.position.y + deltaY),
                        					Random.Range(transform.position.z - deltaZ, transform.position.z + deltaZ)
                        				  );
            // create a new gameObject
            GameObject clone = Instantiate(spawnPrefab, spawnPos, transform.rotation) as GameObject;
        }
    }

	void MakeThingToSpawnAtPos(Vector3 spawnPos) {
		if (gameManager.gameStarted) {
			if (player.GetComponent<Autofly> () == null)
				Debug.Log ("Null autofly");
			autofly.looksAtHoop = false;
			GameObject clone = Instantiate(spawnPrefab, spawnPos, transform.rotation) as GameObject;
		}
	}
}