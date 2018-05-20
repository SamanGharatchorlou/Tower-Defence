using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave03 : MonoBehaviour {

	//add refernce to next wave;
	Wave04 wave04;
	ScoreManager scoreManager;
	EnemyTypes enemyTypes;
	GameObject enemiesLeft;
	int numberOfEnemies;
	int enemyCounter;


	public void StartWave () 
	{
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		enemyTypes = gameObject.GetComponent<EnemyTypes> ();
		wave04 = gameObject.GetComponent<Wave04> ();

		scoreManager.activeWave = 3; //adjust to current wave number
		enemyCounter = 0;

		InvokeRepeating ("SubWaveOne", 3f, 0.5f);
	}

	//spawns 10 basic enemies
	void SubWaveOne() 
	{
		numberOfEnemies = 10;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveTwo", 1f, 0.5f);
		}
	}

	//spawns 5 strong enemies
	void SubWaveTwo() 
	{
		numberOfEnemies = 5;
		EnemySpawner (enemyTypes.strongEnemy, numberOfEnemies);
		enemiesLeft = GameObject.FindGameObjectWithTag ("Enemy");

		if (enemiesLeft == null) 
		{
			CancelInvoke ();
			wave04.StartWave ();
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
