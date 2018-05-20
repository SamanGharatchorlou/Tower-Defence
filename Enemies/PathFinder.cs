using UnityEngine;
using System.Collections;

public class PathFinder : MonoBehaviour {


	public float speed;


	ScoreManager scoreManager;
	EnemyStats enemyStats;
	GameObject pathNodes;
	Vector3 direction;
	Quaternion targetRotation;
	Transform nextNode;
	float step;
	int pathNodeIndex;
	int numbOfChildren;


	void Start () 
	{
		pathNodes = GameObject.Find ("Path");
		pathNodeIndex = 0;
		nextNode = null;
		numbOfChildren = pathNodes.transform.childCount;
	}


	void Update () 
	{
		if (nextNode != null) 
		{
			step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, nextNode.transform.position, step);

			direction = nextNode.transform.position - this.transform.position;

			if(direction != Vector3.zero) 
			{
				targetRotation = Quaternion.LookRotation (direction);
				targetRotation *= Quaternion.Euler (0, 90, 0);
				transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, Time.deltaTime* 5f);
			}
		} 
		else if (nextNode == null && pathNodeIndex < numbOfChildren)
			GetNextNode ();
		
		else
			DestroySelf ();

	}


	void GetNextNode() 
	{
		nextNode = pathNodes.transform.GetChild (pathNodeIndex);
		pathNodeIndex++;			
	}


	void OnTriggerEnter(Collider pathNode) 
	{
		if(pathNode.tag == "PathNode")
		nextNode = null;
	}


	void DestroySelf () 
	{
		enemyStats = gameObject.GetComponent<EnemyStats> ();
		scoreManager = GameObject.FindObjectOfType<ScoreManager> ();


		scoreManager.lives -= enemyStats.lifeValue * (int)Random.Range(0.0f, 20f);

		Destroy (gameObject);
	}





}
