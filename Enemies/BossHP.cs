using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHP : MonoBehaviour {

	public Slider HealthSlider;

	EnemyStats enemyStats;
	float startingHealth;
	float currentHealth;

	// Use this for initialization
	void Start ()
	{
		enemyStats = gameObject.GetComponent<EnemyStats> ();

		startingHealth = enemyStats.health;
		HealthSlider.maxValue = startingHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		currentHealth = enemyStats.health;
		HealthSlider.value = currentHealth;
	}
}
