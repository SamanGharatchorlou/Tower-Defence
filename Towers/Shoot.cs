using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject dome, bullet;

	BulletMovement bulletMovement;
	TowerStats towerStats;
	AudioSource shotAudio;
	GameObject[] enemies;
	GameObject nearestEnemy, projectile;
	Vector3 lookDirection, origin;
	Quaternion targetRotation;
	float distanceToEnemy, closestEnemy, fireCooldown, fireRate, range;

	// Use this for initialization
	void Start () {
		shotAudio = GetComponent<AudioSource> ();

		towerStats = GameObject.FindObjectOfType<TowerStats> ();
		range = towerStats.range * 5f;
		fireRate = towerStats.fireRate;

		origin = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {	
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		// ------ Target Lock -----------
		//TODO: optimise this code
		closestEnemy = Mathf.Infinity;
		nearestEnemy = null;

		foreach (GameObject enemy in enemies) {
			if (enemy != null) {
				distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
				if (distanceToEnemy < closestEnemy && distanceToEnemy <= range) {
					nearestEnemy = enemy;
					closestEnemy = distanceToEnemy;
				}
			}
		}

		if (nearestEnemy == null) //Out of enemies
			return;
		if(nearestEnemy.transform.position == origin)
			return;

		lookDirection = nearestEnemy.transform.position - this.transform.position;
		targetRotation = Quaternion.LookRotation (lookDirection);
		dome.transform.rotation = Quaternion.Euler (0, targetRotation.eulerAngles.y, 0);

		// -------- Shooting -----------
		fireCooldown += Time.deltaTime;

		if (fireCooldown > fireRate)
			FireAt (nearestEnemy.transform);
	}
		

	void FireAt(Transform target) 
	{
		//fires from the cylinder which is a child of the dome and plays the shot sound
		projectile = (GameObject)Instantiate (bullet, dome.transform.GetChild(0).position, dome.transform.rotation);
		shotAudio.Play ();

		bulletMovement = projectile.GetComponent<BulletMovement> ();
		bulletMovement.target = nearestEnemy.transform;

		fireCooldown = 0;
	}
		
}
