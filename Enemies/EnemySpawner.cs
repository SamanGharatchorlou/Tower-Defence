using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemyType;
	public int[] numberOfEnemies;
	public float spawnRate;
    
	int enemyIndex;
	int enemyCounter;

	void Start () {
		enemyIndex = 0;
		enemyCounter = 0;
		InvokeRepeating ("SpawnCaller", 1, spawnRate);
	}

	void SpawnCaller() {
		if (enemyIndex < enemyType.Length) {
			SpawnEnemyType (enemyType [enemyIndex]);
			enemyCounter++;

			if (enemyCounter == numberOfEnemies [enemyIndex]) {
				enemyIndex++;
				enemyCounter = 0;
			}
		}
	}
		
	void SpawnEnemyType(GameObject type){
		Instantiate (type);
	}

}
