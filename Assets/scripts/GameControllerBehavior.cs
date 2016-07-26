using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerBehavior : MonoBehaviour {

	private int baobabCount;
	int plantBump = 12;
	int plantCount = 1; // Number of baobabs spawned at a time
	private int score;

	public AudioSource boing; // Sound effect for fully grown baobab
	public RawImage livesRemaining;
	public Texture[] livesPictures;
	public AudioSource music;
	public int maxBaobabCount = 5;
	float musicVolume = 1.0F; // End game criteria
	public PlanetBehavior planet;
	public float plantRate = 3.24F;
	public GameObject replayButton;
	public Text scoreText;
	public RectTransform shadow;

	// Use this for initialization
	void Start () {
		music.Play();
		replayButton.SetActive (false);
		baobabCount = 0;
		score = -1; // updateScore increments score--init to -1 so game starts with score 0
		updateScore ();
		StartCoroutine (playGame());
	}

	public void updateScore() {
		score += 1;
		scoreText.text = "score: " + score;
	}

	public void updateBaobabCount() {
		baobabCount += 1;
		if (baobabCount == maxBaobabCount) {
			// Game over.
			boing.Play ();
			StopCoroutine (playGame ());
			StartCoroutine (gameOver ());
		} else if (baobabCount < maxBaobabCount) {
			// Play boing + update # of lives
			boing.Play ();
			livesRemaining.texture = livesPictures [Mathf.Min(4, baobabCount - 1)];
		}
	}

	IEnumerator playGame () {
		while (baobabCount < maxBaobabCount) {
			// Check for level up
			// TODO: level by time, not score
			if ((score + 1) % plantBump == 0) {
				plantCount++;
				plantBump *= 2;
				Debug.Log ("LEVEL UP: Spawn Count is now " + plantCount + " at a time. Your next bump will occur at " + plantBump + " points.");
			}
			for (int i = 0; i < plantCount; i++) {
				planet.plantBaobab ();
			}
			yield return new WaitForSeconds (plantRate);
		}
	}

	IEnumerator gameOver () {
		Color shadowColor;
		while (musicVolume > 0)
		{
			// Make shadow backdrop darker
			shadowColor = shadow.GetComponent<Image> ().color;
			shadowColor.a += 0.003f;
			shadow.GetComponent<Image> ().color = shadowColor;
			// Fade out music
			musicVolume = Mathf.Max(musicVolume - (0.25F * Time.deltaTime), 0);
			music.volume = musicVolume;
			Debug.Log ("volume is " + musicVolume);

			yield return new WaitForSeconds (0.00075F);
		}
		replayButton.SetActive (true);
		StopCoroutine (gameOver ());
	}
}
