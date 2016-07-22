using UnityEngine;
using System.Collections;

public class GameControllerBehavior : MonoBehaviour {

	public GUIText scoreText;
	public GameObject replayButton;
	public PlanetBehavior planet;
	private int score;
	private int baobads;
	float nextPlant = 2.0F;
	int spawnCount = 1;
	int spawnBump = 10;

	// Use this for initialization
	void Start () {
		replayButton.SetActive (false);
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
			replayButton.SetActive (true);
		}
	}

	IEnumerator gameDifficulty () {
		while (baobads < 5) {
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
