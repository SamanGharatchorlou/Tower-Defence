using UnityEngine;
using System.Collections;

public class TowerSelector : MonoBehaviour {

	public GameObject tower;
	public GameObject[] towerTypes;

    // make into switch statement
	public void TowerSelectionNumber(string towerType) {
		if(towerType == "basicTower")
			tower = towerTypes [0];
		if (towerType == "sniperTower")
			tower = towerTypes [1];
	}
		
}
