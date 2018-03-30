using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/* Description: Spawns a given prefab.
 * Run Type: continuous
 * Time: Random time ranging from minSecondsBetweenSpawning to maxSecondsBetweenSpawning
 * Location: Random location between (x +- deltaX, y +- deltaY, z +- deltaZ )
 */


public class SpawnGameObjects : MonoBehaviour {

	public GameObject spawnPrefab;
    public GameManager gameManager;


	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;

	public float deltaX = 0;
	public float deltaY = 0;
	public float deltaZ = 0;
	
//	private float savedTime;
//	private float secondsBetweenSpawning;

	// Use this for initialization
	void Start () {
//		savedTime = 0;
//        secondsBetweenSpawning = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (gameManager.gameMode == GameMode.Hoop || gameManager.gameMode == GameMode.FreeRoam) {
			//if ((Time.time - savedTime >= secondsBetweenSpawning) && (GameObject.FindGameObjectWithTag ("MagicHoop") == false)) { // is it time to spawn again?
			if (GameObject.FindGameObjectWithTag ("MagicHoop") == false) {
				MakeThingToSpawn ();
				//savedTime = Time.time; // store for next spawn
				//secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
			}	
		}
	}

	void MakeThingToSpawn() {
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
}