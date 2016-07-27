using UnityEngine;
using System.Collections;

public class BaobabBehavior : MonoBehaviour 
{
	private GameControllerBehavior controller;
	private Coroutine coroutine;
	public Material[] foliageColors;
	bool isPickable = true;
	AudioSource pop;

	void Start () 
	{
		coroutine = StartCoroutine(ScaleOverTime(3));

		//Find the game controller object in the scene
		GameObject controllerObject = GameObject.FindWithTag ("GameController");
		if (controllerObject != null) {
			controller = controllerObject.GetComponent<GameControllerBehavior> ();
			pop = controllerObject.GetComponents<AudioSource>()[1];
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
			pop.Play ();
			StopCoroutine (coroutine);
			Destroy (gameObject);
			controller.updateScore ();
		}
	}

	IEnumerator ScaleOverTime(float time)
	{
		float girthTime = 0.75f;
		Vector3 babyScale = new Vector3(0.08f, 0.24f, 0.08f); // Cute little baobab
		Vector3 saplingScale = new Vector3(0.95f, 1.0f, 0.95f); // Sapling baobab
		Vector3 finalScale = new Vector3(1.0f, 1.0f, 1.0f); // Thicker, adult baobab

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
			gameObject.transform.localScale = Vector3.Lerp(saplingScale, finalScale, currentTime / girthTime);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= girthTime);

		// Baobab is fully grown
		isPickable = false;
		changeFoliage (foliageColors [1]);
		controller.updateBaobabCount ();
	}

}