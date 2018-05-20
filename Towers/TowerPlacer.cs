using UnityEngine;
using System.Collections;

public class TowerPlacer : MonoBehaviour {

	ScoreManager scoreManager;
	TowerStats towerStats;
	TowerSelector towerSelector;
	GameObject tower;
	GameObject selectedTower;


	void OnMouseUp() 
	{
		towerSelector = GameObject.FindObjectOfType<TowerSelector> ();
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
		selectedTower = towerSelector.tower;

		if (selectedTower == null) 
		{
			return;
		}

		if (scoreManager.activeWave > 0 && scoreManager.money >= selectedTower.GetComponent<TowerStats> ().price) 
		{
			transform.eulerAngles = new Vector3 (0, 90, 0);
			tower = (GameObject)Instantiate (selectedTower, transform.position, transform.rotation);

			towerStats = tower.GetComponent<TowerStats> ();
			scoreManager.money -= towerStats.price;

			Destroy (gameObject);
		}
	}

}
