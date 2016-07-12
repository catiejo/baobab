using UnityEngine;
using System.Collections;

public class BaobabTopBehavior : MonoBehaviour {
	bool isPickable = true;

	void Start ()
	{
		StartCoroutine (PleaseHold (7));
	}

	void OnMouseDown()
	{
		// Destroy entire tree on click
		if (isPickable) {
			Destroy (transform.parent.gameObject);
		}
	}

	//HACK
	IEnumerator PleaseHold(int time) {
		yield return new WaitForSeconds(time);
		isPickable = false;
	}
}
