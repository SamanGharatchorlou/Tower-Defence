using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave04 : MonoBehaviour {

	Wave05 wave05;
	ScoreManager scoreManager;
	EnemyTypes enemyTypes;
	GameObject enemiesLeft;
	int numberOfEnemies;
	int enemyCounter;


	public void StartWave () 
	{
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		enemyTypes = gameObject.GetComponent<EnemyTypes> ();
		wave05 = gameObject.GetComponent<Wave05> ();

		scoreManager.activeWave = 4; //adjust to current wave number
		enemyCounter = 0;

		InvokeRepeating ("SubWaveOne", 3f, 0.5f);
	}

	//spawns 5 strong enemies
	void SubWaveOne() 
	{
		numberOfEnemies = 5;
		EnemySpawner (enemyTypes.strongEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveTwo", 1f, 0.5f);
		}
	}

	//spawns 15 basic enemies
	void SubWaveTwo() 
	{
		numberOfEnemies = 15;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveThree", 1f, 0.5f);
		}
	}

	//spawns 3 strong enemies
	void SubWaveThree() 
	{
		numberOfEnemies = 3;
		EnemySpawner (enemyTypes.strongEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveFour", 1f, 0.5f);
		}
	}

	//spawns 5 strong enemies
	void SubWaveFour() 
	{
		numberOfEnemies = 10;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);
		enemiesLeft = GameObject.FindGameObjectWithTag ("Enemy");

		if (enemiesLeft == null) 
		{
			CancelInvoke ();
			wave05.StartWave ();
			//isWave04Active = false; //adjust number
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
