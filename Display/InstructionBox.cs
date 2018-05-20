using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InstructionBox : MonoBehaviour {

	public Text title;
	public Text instructions;
	public GameObject ready;
	public bool gameOn;

	Wave01 wave01;

	// Use this for initialization
	void Start () 
	{
		
		wave01 = GameObject.FindObjectOfType<Wave01> ();

		title.text = "Saman's Tower Defence";
		instructions.text = "Stop the enemies from reaching your base by building towers to destroy them. " +
		"6 waves of enemies (5 waves + boss level) will enter from the east and move towards your base on the north side of the map. " +
		"Build a tower by using the buttons on the left and placing it on a tile." +
		"\n\n- Remove a tower by holding 'x' and selecting the tower. This will refund 50% of its cost." +
		"\n- Upgrade your towers by selecting them then hitting the upgrade button (upgrade price on the right" +
			"side of the tower selector button)" +
		"\n\nOnce you press ready you have 10 seconds until the first wave!";
	}
	

	public void Ready()
	{
		wave01.StartWave ();
		Destroy (gameObject);
		Destroy (ready);

	}
}
