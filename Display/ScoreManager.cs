using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	// Scores 
	bool runLoop;

	public Text moneyText;
	public Text lifeText;
	public Text scoreText;
	public Text waveNumber;
	public int activeWave;
	public int money;
	[HideInInspector] public int score;
	[HideInInspector] public int lives;


	// Tower stats
	TowerStats towerStats;
	GameObject selectedTower;
	int towerNumber;
	float dmgPerSec;

	public GameObject[] Towers;
	public Text price;
	public Text damage;
	public Text fireRate;
	public Text range;
	public Text dps;


	void Start () 
	{
		score = 0;
		lives = 20;
		money = 150;
		runLoop = true;
	}
	

	void Update () 
	{
		// display lives, money & score
		if (lives > 0) 
		{
			lifeText.text = "Lives: " + lives.ToString ();
			moneyText.text = "Money: £" + money.ToString ();
			scoreText.text = "Score: " + score.ToString ();
		} 
		else if (lives <= 0 && runLoop) 
		{
			lives = 0;
			lifeText.text = "Lives: 0";
			moneyText.text = "";
			scoreText.text = "Final score: " + score.ToString ();
			AudioListener.volume = 0;
			runLoop = false;
		}

		// display current wave number
		if (activeWave != 6)
			waveNumber.text = "Wave: " + activeWave;
		else if (activeWave == 6)
			waveNumber.text = "Boss Wave Mother F*!k@r!";
	}

	// displays stats from button press
	public void Stats(string tower) 
	{
		if(tower == "basicTower")
			towerNumber = 0;
		if (tower == "sniperTower")
			towerNumber = 1;
		
		towerStats = Towers[towerNumber].GetComponent<TowerStats> ();

		price.text = "Price: " + towerStats.price;
		damage.text = "Damage: " + towerStats.GetDamage();
		fireRate.text = "Shots per second: " + 1/towerStats.fireRate;
		range.text = "Range: " + towerStats.range;

		dmgPerSec = towerStats.GetDamage() / towerStats.fireRate;
		dps.text = "DPS: " + dmgPerSec;
	}


	// displays stats from tower gameObject press
	public void UpdateTheTowerInfo(){
		// finds the selected object
		selectedTower = GameObject.FindGameObjectWithTag ("Selected");

		towerStats = selectedTower.GetComponent<TowerStats> ();

		price.text = "Price: " + towerStats.price;
		damage.text = "Damage: " + towerStats.GetDamage();
		fireRate.text = "Fire Rate: " + towerStats.fireRate;
		range.text = "Range: " + towerStats.range;

		dmgPerSec = towerStats.GetDamage() / towerStats.fireRate;
		dps.text = "DPS: " + dmgPerSec;
	}
		
}
