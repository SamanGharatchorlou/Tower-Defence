using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour {

	public GameObject basicExplosion;
	public float health;
	public int scoreValue;
	public int reward;
	public int lifeValue;

	ScoreManager scoreManager;
	BulletMovement bulletMovement;
	GameObject projectile;


	void OnTriggerEnter(Collider bullet) 
	{
		if (bullet.tag == "Projectile") 
		{
			projectile = GameObject.FindGameObjectWithTag("Projectile");
			bulletMovement = projectile.GetComponent<BulletMovement> ();

			health -= bulletMovement.dmg;
			Destroy (bullet.gameObject);

			if (health <= 0) 
			{
				Instantiate (basicExplosion, transform.position, transform.rotation);
				Die ();
			}

		}
	}


	void Die() 
	{
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();

		scoreManager.money += reward;
		scoreManager.score += scoreValue;

		Destroy (gameObject);
	}

		
}
