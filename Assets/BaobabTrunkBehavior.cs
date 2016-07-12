using UnityEngine;
using System.Collections;

public class BaobabTrunkBehavior : MonoBehaviour 
{
	bool isPickable = true;
	void Start () 
	{
		StartCoroutine(ScaleOverTime(5));
	}
	void OnMouseDown()
	{
		if (isPickable) {
			Destroy (gameObject);
		}
	}

	IEnumerator ScaleOverTime(float time)
	{
		float girthTime = 2f;
		Vector3 babyScale = new Vector3(0.02f, 0.06f, 0.02f); // Cute little baobab
		Vector3 saplingScale = new Vector3(0.15f, 0.25f, 0.15f); // Sappling baobab
		Vector3 finalScale = new Vector3(0.25f, 0.25f, 0.25f); // Thicker, adult baobab

		// Grow the whole tree
		float currentTime = 0.0f;
		do
		{
			gameObject.transform.localScale = Vector3.Lerp(babyScale, saplingScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

		// Reset time and grow the girth
		currentTime = 0.0f;
		do
		{
			gameObject.transform.localScale = Vector3.Lerp(saplingScale, finalScale, currentTime / girthTime);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= girthTime);

		isPickable = false;

	}

}