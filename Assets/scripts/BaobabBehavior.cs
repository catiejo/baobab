using UnityEngine;
using System.Collections;

public class BaobabBehavior : MonoBehaviour 
{
	public Material[] foliageColors;
	AudioSource pop;
	public Renderer rend;
	private GameControllerBehavior controller;
	bool isPickable = true;
	private Coroutine coroutine;

	void Start () 
	{
		coroutine = StartCoroutine(ScaleOverTime(3));
		GameObject controllerObject = GameObject.FindWithTag ("GameController");
		if (controllerObject != null) {
			controller = controllerObject.GetComponent<GameControllerBehavior> ();
			pop = controllerObject.GetComponent<AudioSource>();
		} else {
			Debug.Log ("Cannot find game controller...waa waa waaaaaaa");
		}
		pop.enabled = true;
	}

	void changeFoliage(Material foliageColor) {
		Renderer[] renderers = transform.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in renderers){
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
		changeFoliage (foliageColors [0]);

		// Reset time and grow the girth
		currentTime = 0.0f;
		do
		{
			gameObject.transform.localScale = Vector3.Lerp(saplingScale, finalScale, currentTime / girthTime);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= girthTime);

		isPickable = false;
		changeFoliage (foliageColors [1]);
		controller.updateBaobads ();
	}

}