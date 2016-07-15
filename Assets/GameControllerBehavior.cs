using UnityEngine;
using System.Collections;

public class GameControllerBehavior : MonoBehaviour {

	public GUIText scoreText;
	public PlanetBehavior planet;
	private int score;
	private int baobads;
	float nextPlant = 2.0F;
	int spawnCount = 1;

	// Use this for initialization
	void Start () {
		score = -1;
		updateScore ();
		baobads = 0;
		StartCoroutine (gameDifficulty());
	}

	public void updateScore() {
		score += 1;
		scoreText.text = "Score: " + score;
	}

	public void updateBaobads() {
		baobads += 1;
		Debug.Log ("fully grown baobabs: " + baobads);
		if (baobads > 5) {
			StopCoroutine (gameDifficulty ());
			scoreText.text = "GAME OVER";
		}
	}

	IEnumerator gameDifficulty () {
		while (baobads <= 5) {
			if ((score + 1) % 10 == 0) {
				spawnCount++;
			}
			if ((score + 1) % 20 == 0) {
				nextPlant -= Mathf.Max(nextPlant -0.5F, 0.5F);
			}
			for (int i = 0; i < spawnCount; i++) {
				planet.plantBaobab ();
			}
			yield return new WaitForSeconds (nextPlant);
		}
	}
}
