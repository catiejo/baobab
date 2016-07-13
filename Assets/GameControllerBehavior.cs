using UnityEngine;
using System.Collections;

public class GameControllerBehavior : MonoBehaviour {

	public GUIText scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score = -1; //Kinda hacky, but no fucks.
		updateScore ();
	}

	public void updateScore() {
		score += 1;
		scoreText.text = "Score: " + score;
	}
}
