using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public ScoreManager scoreManager;
	public Text restartText;

	Animator loseAnimation;


	void Start () 
	{
		loseAnimation = GetComponent<Animator> ();

		transform.position = transform.position + new Vector3 (0, 0, 1f);
	}

	//TODO: input.getkeydown not working anymore "r press" is never seen
	// seems to work now... somehow?
	void Update ()
	{
		if (scoreManager.lives == 0) 
		{
			Debug.Log ("no lives");
			loseAnimation.SetTrigger ("GameOver");
			restartText.text = "Press 'R' to try again";

			if (Input.GetKey(KeyCode.R)) {
				SceneManager.LoadScene ("Level01");
			}
		}


		if (Input.GetKey("escape"))
			Application.Quit();

	}
		
}
