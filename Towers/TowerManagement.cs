using UnityEngine;
using System.Collections;

public class TowerManagement : MonoBehaviour {

	// remove tower
	TowerStats towerStats;
	TowerStats childTowerStats;
	ScoreManager scoreManager;
	GameObject tile;
	int childTowerPrice;

	public GameObject towerTile, childTower;

	// upgrade selection
	GameObject oldSelection;

	public GameObject upgradedTower;

	void Start () {
		towerStats = gameObject.GetComponent<TowerStats> ();
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();
	}


	void OnMouseUp() {
		// remove tower
		//holding x while selecting a tower removes it returning 50% of its price
		if (Input.GetKey (KeyCode.X)) {
			childTowerPrice = 0;
			if (childTower != null) {
				childTowerStats = childTower.GetComponent<TowerStats> ();
				childTowerPrice = childTowerStats.price;
			}
			scoreManager.money += (towerStats.price + childTowerPrice) / 2;
			tile = (GameObject)Instantiate (towerTile, transform.position, transform.rotation);
			tile.transform.eulerAngles = new Vector3 (90, 0, 0);
			Destroy (gameObject);
		}
	}

	void OnMouseDown() {
		// upgrade selection
		// sotres the currently selected tower as the selection
		oldSelection = GameObject.FindGameObjectWithTag ("Selected");
		if(oldSelection != null)
			oldSelection.tag = "Untagged";
		
		gameObject.tag = "Selected";

		// updates the tower stats info section when tower is selected
		scoreManager.UpdateTheTowerInfo ();
	}

}
