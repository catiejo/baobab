using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerBehavior : MonoBehaviour {

	public AudioSource music;
	public AudioSource boing;
	public AudioSource pop;
	public RawImage lives;
	public Texture[] livesPictures;
	float musicVolume = 1.0F;
	public GUIText scoreText;
	public GameObject replayButton;
	public PlanetBehavior planet;
	private int score;
	private int baobads;
	public int maxBaobads = 5;
	private AudioSource soundEffect;
	float nextPlant = 3.24F;
	int spawnCount = 1;
	int spawnBump = 12;

	// Use this for initialization
	void Start () {
		music.Play();
		replayButton.SetActive (false);
		score = -1;
		updateScore ();
		baobads = 0;
		StartCoroutine (gameDifficulty());
	}

	public void updateScore() {
		score += 1;
		scoreText.text = "score: " + score;
	}

	public void updateBaobads() {
		baobads += 1;
		lives.texture = livesPictures [Mathf.Min(4, baobads - 1)];
		boing.Play ();
		if (baobads >= maxBaobads) {
			StopCoroutine (gameDifficulty ());
			replayButton.SetActive (true);
			StartCoroutine(fadeOut ());
		}
	}

	IEnumerator gameDifficulty () {
		while (baobads < maxBaobads) {
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

	IEnumerator fadeOut () {
		musicVolume = 0.8F;
		while (musicVolume > 0)
		{
			musicVolume = Mathf.Max(musicVolume - (0.15F * Time.deltaTime), 0);
			music.volume = musicVolume;
			Debug.Log ("volume is " + musicVolume);
			yield return new WaitForSeconds (0.0005F);
		}
		StopCoroutine (fadeOut ());
	}
}
