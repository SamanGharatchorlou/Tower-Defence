using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveBoss : MonoBehaviour {

	ScoreManager scoreManager;
	EnemyTypes enemyTypes;

	public bool isWaveBossActive;
	public GameObject bossSpawn;


	public void StartWave () 
	{
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		enemyTypes = gameObject.GetComponent<EnemyTypes> ();

		scoreManager.activeWave = 6; //adjust to current wave number
		isWaveBossActive = true;

		Instantiate (enemyTypes.enemyType [enemyTypes.boss], transform.position, transform.rotation);
	}
		


}
