﻿using UnityEngine;
using System.Collections;

public class BaobabTrunkBehavior : MonoBehaviour 
{
	void Start () 
	{
		StartCoroutine(ScaleOverTime(5));
	}
	void OnMouseDown()
	{
		Destroy (gameObject);
	}

	IEnumerator ScaleOverTime(float time)
	{
		Vector3 originalScale = new Vector3((gameObject.transform.localScale.x * 0.1f), (gameObject.transform.localScale.y * 0.3f), (gameObject.transform.localScale.z * 0.1f));
		Vector3 destinationScale = new Vector3(0.25f, 0.25f, 0.25f);

		float currentTime = 0.0f;

		do
		{
			gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
			currentTime += Time.deltaTime;
			yield return null;
		} while (currentTime <= time);

	}

}