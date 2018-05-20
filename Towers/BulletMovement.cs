using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public float bulletSpeed;
	public float dmg;
	public Transform target;
    
	Vector3 direction;
	Quaternion targetRotation;
	float step;

	void Update () {
	
		if (target != null) 
		{
			step = bulletSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, target.position, step);

			direction = target.position - this.transform.position;

			if (direction != Vector3.zero) 
			{
				targetRotation = Quaternion.LookRotation (direction);
				targetRotation *= Quaternion.Euler (90, 0, 0);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Mathf.Infinity);
			}
		} 
		else
			Destroy (gameObject);
	}
		
}
