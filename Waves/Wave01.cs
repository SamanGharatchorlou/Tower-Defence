using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave01 : MonoBehaviour {
	
	Wave02 wave02;
	ScoreManager scoreManager;
	EnemyTypes enemyTypes;
	GameObject enemiesLeft;
	AudioSource backgroundMusic;
	int numberOfEnemies;
	int enemyCounter;
	float startTime;


	public void StartWave () 
	{
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		enemyTypes = gameObject.GetComponent<EnemyTypes> ();
		wave02 = gameObject.GetComponent<Wave02> (); // adjust reference to next wave
		backgroundMusic = GetComponent<AudioSource> ();

		scoreManager.activeWave = 1; //adjust to current wave number
		enemyCounter = 0;
		startTime = 10f;

		InvokeRepeating ("SubWaveOne", startTime, 0.5f);

		StartCoroutine (WaitForPlay ());
	}


	//spawns 10 basic enmies
	void SubWaveOne() 
	{
		numberOfEnemies = 10;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);
		enemiesLeft = GameObject.FindGameObjectWithTag ("Enemy");

		if (enemiesLeft == null) 
		{
			CancelInvoke ();
			wave02.StartWave ();
		}	
	}


	// -- This does not change --
	//spawns the enemytype a given number of times when called by an InvokeRepeating
	void EnemySpawner(int enemyTypeIndex,int numberOfEnemies) 
	{
		if (enemyCounter < numberOfEnemies) 
		{
			Instantiate (enemyTypes.enemyType [enemyTypeIndex]);
			enemyCounter++;
		}
	}


	IEnumerator WaitForPlay()
	{
		yield return new WaitForSeconds (startTime);
		AudioListener.volume = 1;
		backgroundMusic.Play ();
	}


}

