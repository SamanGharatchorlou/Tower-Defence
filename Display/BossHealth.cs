using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	GameObject boss;
	EnemyStats enemyStats;
	WaveBoss waveBoss;

	public GameObject spawnManager;
	public Texture2D frame;
	public Rect framePosition;

	public Texture2D healthBar;
	public Rect healthBarPosition;
	public float xPos, yPos, widthAdjust, heightAdjust;

	float startingHealth, currentHealth, healthPercentage;
	float death; //hides when no boss is present (=1 when present, =0 when not)

	//TODO: find a way to get the starting health without having to manually set it to 5000
	//maybe adjust the enemy stats script?
	//startinghealth cannot be found as there's no refence to the script. you also cant
	//put it in the start function as the boss is instantiated at a random time
	//add a loop of some sort?

	void Start () {
		waveBoss = spawnManager.GetComponent<WaveBoss> ();

		healthPercentage = 1f;
		startingHealth = 40000f; //enemyStats.health;
		death = 0;
	}
	
	void Update () {
        if (waveBoss.isWaveBossActive) {
            boss = GameObject.FindGameObjectWithTag("Boss");

            if (boss != null) {
                enemyStats = boss.GetComponent<EnemyStats>();
                death = 1;
            }
            currentHealth = enemyStats.health;
            healthPercentage = currentHealth / startingHealth;
        }
	}


	void OnGUI() {
			DrawFrame ();
			DrawBar (); 
	}

	void DrawFrame() {
		framePosition.x = (Screen.width - framePosition.width) / 2;
		framePosition.y = Screen.height * 0.06f;

		framePosition.width = Screen.width * 0.25f * death;
		framePosition.height = Screen.height * 0.05f;

		GUI.DrawTexture (framePosition, frame);
	}

	void DrawBar() {
		healthBarPosition.x = framePosition.x * xPos;
		healthBarPosition.y = Screen.height * yPos;

		healthBarPosition.width = framePosition.width * widthAdjust * healthPercentage * death;
		healthBarPosition.height = framePosition.height * heightAdjust;

		GUI.DrawTexture (healthBarPosition, healthBar);
	}

}
