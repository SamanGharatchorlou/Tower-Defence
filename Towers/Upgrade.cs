using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {


	ScoreManager scoreManager;
	TowerStats upgradeTowerStats;
	GameObject objectToUpgrade;
	TowerManagement towerManagement;
	GameObject towerUpgrade;

	public void UpgradeTower()
	{
		// finds the selected object
		objectToUpgrade = GameObject.FindGameObjectWithTag ("Selected");
		if (objectToUpgrade != null) 
		{
			// gets the towerManagement script
			towerManagement = objectToUpgrade.GetComponent<TowerManagement> ();
			// gets the tower that the object upgrades to
			towerUpgrade = towerManagement.upgradedTower;
			// gets the towerStats script of the upgraded tower
			if (towerUpgrade != null)
				upgradeTowerStats = towerUpgrade.GetComponent<TowerStats> ();
			else
				return;

			scoreManager = GameObject.FindObjectOfType<ScoreManager> ();


			if (scoreManager.money >= upgradeTowerStats.price && objectToUpgrade != null && towerUpgrade != null) {
				scoreManager.money -= upgradeTowerStats.price;
				Vector3 postion = objectToUpgrade.transform.position;
				Quaternion rotation = objectToUpgrade.transform.rotation;

				Instantiate (towerUpgrade, postion, rotation);
				Destroy (objectToUpgrade);
			}

		}

	}





}
