using UnityEngine;
using System.Collections;

public class TowerStats : MonoBehaviour {

	public int price;
	public float range;
	public float fireRate;
	public float damage;
	public GameObject rangeIdentifier;
	public GameObject bullet;

	BulletMovement bulletMovement;
	GameObject rangeGuide;


	// shows tower range
	void OnMouseDown()
	{
		rangeGuide = Instantiate (rangeIdentifier, transform.position, transform.rotation) as GameObject;
		rangeGuide.transform.localScale = new Vector3 (range * 10f, 0.1f, range * 10f);
	}

	// unshows tower range
	void OnMouseUp()
	{
		rangeGuide.transform.localScale = new Vector3 (0f, 0f, 0f);
	}

	// gets damage from the bullet
	public float GetDamage()
	{
		bulletMovement = bullet.GetComponent<BulletMovement> ();
		damage = bulletMovement.dmg;
		return damage;
	}
		

}
