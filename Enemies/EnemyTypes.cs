using UnityEngine;
using System.Collections;

public class EnemyTypes : MonoBehaviour {

	public GameObject[] enemyType;
	[HideInInspector] public int basicEnemy;
	[HideInInspector] public int strongEnemy;
	[HideInInspector] public int boss;

	// Use this for initialization
	void Start () {

		basicEnemy = 0;
		strongEnemy = 1;
		boss = 2;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
