using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerBehavior : MonoBehaviour {

	private int _baobabCount;
	private float _musicVolume = 1.0F; // Music fades as game ends
	private int _plantCount = 1; // Number of baobabs spawned at a time
	private int _score;

	public AudioSource boing; // Sound effect for fully grown baobab
	public float levelRate = 35.0F; // Timed to repetition of the music
	public AudioSource music;
	public int maxBaobabCount = 5;
	public PlanetBehavior planet;
	public float plantRate = 1.62F; // Timed to repetition of the music
	public RawImage remainingLivesDisplay;
	public Texture[] remainingLivesTextures;
	public GameObject replayButton;
	public Text scoreText;
	public RectTransform shadow;

	// Use this for initialization
	void Start () {
		music.Play();
		replayButton.SetActive (false);
		_baobabCount = 0;
		_score = -1; // updateScore increments score--init to -1 so game starts with score 0
		updateScore ();
		StartCoroutine (playGame());
	}

	public void updateScore() {
		_score += 1;
		scoreText.text = "score: " + _score;
	}

	public void updateBaobabCount() {
		_baobabCount += 1;
		remainingLivesDisplay.texture = remainingLivesTextures [System.Math.Min(remainingLivesTextures.Length - 1, _baobabCount)];
		if (_baobabCount == maxBaobabCount) {
			// Game over.
			boing.Play ();
			StopCoroutine (playGame ());
			StartCoroutine (gameOver ());
		} else if (!tooManyTrees()) {
			// Play boing + update # of lives
			boing.Play ();
		}
	}

	bool tooManyTrees () {
		return _baobabCount >= maxBaobabCount;
	}

	IEnumerator playGame () {
		StartCoroutine (levelUp());
		while (!tooManyTrees()) {
			for (int i = 0; i < _plantCount; i++) {
				planet.plantBaobab ();
			}
			yield return new WaitForSeconds (plantRate);
		}
	}

	IEnumerator levelUp() {
		while (!tooManyTrees ()) {
			yield return new WaitForSeconds (levelRate);
			_plantCount++;
			Debug.Log ("LEVEL UP: Baobabs will grow " + _plantCount + " at a time.");
		}
	}

	IEnumerator gameOver () {
		Color shadowColor;
		float endGameFadeRate = 0.25f;
		while (_musicVolume > 0)
		{
			// Make shadow backdrop darker
			shadowColor = shadow.GetComponent<Image> ().color;
			shadowColor.a += 0.003f;
			shadow.GetComponent<Image> ().color = shadowColor;
			// Fade out music
			_musicVolume = Mathf.Max(_musicVolume - (endGameFadeRate * Time.deltaTime), 0);
			music.volume = _musicVolume;

			yield return null;
		}
		replayButton.SetActive (true);
		StopCoroutine (gameOver ());
	}
}
