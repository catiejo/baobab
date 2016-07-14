using UnityEngine;
using System.Collections;

public class GameControllerBehavior : MonoBehaviour {

	public GUIText scoreText;
	public PlanetBehavior planet;
	private int score;
	float nextPlant = 5.0F;

	// Use this for initialization
	void Start () {
//		Invoke ("planet.plantBaobab()", 0); //Start by planting a baobab.
		score = -1;
		updateScore ();
//		StartCoroutine (gameDifficulty());
	}

	public void updateScore() {
		score += 1;
		scoreText.text = "Score: " + score;
	}

//	IEnumerator gameDifficulty () {
//		if (score % 10 == 0) {
//			nextPlant -= 0.5F;
//		}
//		yield return new WaitForSeconds (nextPlant);
//		if (!planet.plantBaobab ()) {
//			StopCoroutine (gameDifficulty());
//			scoreText.text = "Game Over";
//		}
//	}
}
