using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave05 : MonoBehaviour {

	//add refernce to next wave;
	WaveBoss waveBoss;
	ScoreManager scoreManager;
	EnemyTypes enemyTypes;
	GameObject enemiesLeft;
	int numberOfEnemies;
	int enemyCounter;


	public void StartWave () 
	{
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		enemyTypes = gameObject.GetComponent<EnemyTypes> ();
		waveBoss = gameObject.GetComponent<WaveBoss> ();

		scoreManager.activeWave = 5; //adjust to current wave number
		enemyCounter = 0;

		InvokeRepeating ("SubWaveOne", 3f, 0.5f);
	}

	//spawns 15 basic enemies
	void SubWaveOne() 
	{
		numberOfEnemies = 15;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveTwo", 1f, 0.5f);
		}
	}

	//spawns 10 strong enemies
	void SubWaveTwo() 
	{
		numberOfEnemies = 10;
		EnemySpawner (enemyTypes.strongEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveThree", 1f, 0.5f);
		}
	}

	//spawns 10 basic enemies
	void SubWaveThree() 
	{
		numberOfEnemies = 10;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveFour", 1f, 0.5f);
		}
	}

	//spawns 10 strong enemies
	void SubWaveFour() 
	{
		numberOfEnemies = 10;
		EnemySpawner (enemyTypes.strongEnemy, numberOfEnemies);
		enemiesLeft = GameObject.FindGameObjectWithTag ("Enemy");

		if (enemiesLeft == null) 
		{
			CancelInvoke ();
			waveBoss.StartWave ();
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


}
