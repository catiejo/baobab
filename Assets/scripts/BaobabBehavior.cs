using UnityEngine;
using System.Collections;

public class BaobabBehavior : MonoBehaviour 
{
	private GameControllerBehavior _controller;
	private Coroutine _coroutine;
	public Material[] foliageColors;
	bool isPickable = true;
	AudioSource pickSound;

	public Vector3 babyScale = new Vector3(0.08f, 0.24f, 0.08f); // Cute little baobab
	public Vector3 finalScale = new Vector3(1.0f, 1.0f, 1.0f); // Thicker, adult baobab
	public Vector3 saplingScale = new Vector3(0.95f, 1.0f, 0.95f); // Sapling baobab
	public float timeToSapling = 3.0f;
	public float timeToAdult = 0.75f;

	void Start () 
	{
		_coroutine = StartCoroutine(ScaleOverTime(timeToSapling));

		//Find the game controller object in the scene
		GameObject controllerObject = GameObject.FindWithTag ("GameController");
		if (controllerObject != null) {
			_controller = controllerObject.GetComponent<GameControllerBehavior> ();
			pickSound = controllerObject.GetComponents<AudioSource>()[1];
		} else {
			Debug.Log ("BaobabBehavior cannot find game controller.");
		}
	}

	//Helper function to change the color of the leaves
	void changeFoliage(Material foliageColor) {
		Renderer[] foliageRenderers = transform.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in foliageRenderers){
			if (r.transform.gameObject.tag == "foliage") {
				r.material = foliageColor;
			}
		}
	}

	void OnMouseDown()
	{
		if (isPickable) {
			pickSound.Play ();
			StopCoroutine (_coroutine);
			Destroy (gameObject);
			_controller.updateScore ();
		}
	}

	IEnumerator ScaleOverTime(float time)
	{

		// Grow the whole tree
		float currentTime = 0.0f;
		do
		{
			gameObject.transform.localScale = Vector3.Lerp(babyScale, saplingScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		// Reset time and grow the girth (change foliage to indicate it's almost fully grown)
		changeFoliage (foliageColors [0]);
		currentTime = 0.0f;
		do
		{
			gameObject.transform.localScale = Vector3.Lerp(saplingScale, finalScale, currentTime / timeToAdult);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= timeToAdult);
		gameObject.transform.localScale = finalScale;

		// Baobab is fully grown
		isPickable = false;
		changeFoliage (foliageColors [1]);
		_controller.updateBaobabCount ();
	}

}