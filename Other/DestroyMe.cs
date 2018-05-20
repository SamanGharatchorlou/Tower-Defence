using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (StopExplosion ());
	}
	
	IEnumerator StopExplosion()
	{
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
