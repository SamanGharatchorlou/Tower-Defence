using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wave02 : MonoBehaviour {

	Wave03 wave03;
	ScoreManager scoreManager;
	EnemyTypes enemyTypes;
	GameObject enemiesLeft;
	int numberOfEnemies;
	int enemyCounter;


	public void StartWave () 
	{
		scoreManager = gameObject.GetComponent<ScoreManager> ();
		enemyTypes = gameObject.GetComponent<EnemyTypes> ();
		wave03 = gameObject.GetComponent<Wave03> ();

		scoreManager.activeWave = 2; //adjust to current wave number
		enemyCounter = 0;

		InvokeRepeating ("SubWaveOne", 3f, 0.5f);
	}

	//spawns 5 basic enemies
	void SubWaveOne() 
	{
		numberOfEnemies = 5;
		EnemySpawner (enemyTypes.basicEnemy, numberOfEnemies);

		if (enemyCounter == numberOfEnemies) 
		{
			CancelInvoke ();
			enemyCounter = 0;
			InvokeRepeating ("SubWaveTwo", 1f, 0.5f);
		}
	}

	//spawns 3 strong enemies
	void SubWaveTwo() 
	{
		numberOfEnemies = 3;
		EnemySpawner (enemyTypes.strongEnemy, numberOfEnemies);
		enemiesLeft = GameObject.FindGameObjectWithTag ("Enemy");

		if (enemiesLeft == null) 
		{
			CancelInvoke ();
			wave03.StartWave ();
			//isWave02Active = false;
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
