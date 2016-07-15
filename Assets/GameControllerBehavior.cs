using UnityEngine;
using System.Collections;

public class GameControllerBehavior : MonoBehaviour {

	public GUIText scoreText;
	public PlanetBehavior planet;
	private int score;
	private int baobads;
	float nextPlant = 3.0F;
	int plantBump = 15;
	int spawnCount = 1;
	int spawnBump = 10;

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
		if (baobads > 5) {
			StopCoroutine (gameDifficulty ());
			//TODO: add another text GUI to display game over.
			//TODO: not be able to click trees after the game is over?
		}
	}

	IEnumerator gameDifficulty () {
		while (baobads < 5) {
			//TODO tweak growth rate for leveling up?
			if ((score + 1) % plantBump == 0) {
				nextPlant = Mathf.Max(nextPlant - 0.5F, 0.5F);
				plantBump *= 2;
				Debug.Log ("LEVEL UP: Plant Rate is now " + nextPlant + " seconds. Your next bump will occur at " + plantBump + " points.");
			}
			if ((score + 1) % spawnBump == 0) {
				spawnCount++;
				spawnBump *= 2;
				Debug.Log ("LEVEL UP: Spawn Count is now " + spawnCount + " at a time. Your next bump will occur at " + spawnBump + " points.");
			}
			for (int i = 0; i < spawnCount; i++) {
				planet.plantBaobab ();
			}
			yield return new WaitForSeconds (nextPlant);
		}
	}
}
