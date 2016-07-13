using UnityEngine;
using System.Collections;

public class BaobabTopBehavior : MonoBehaviour {
	private GameControllerBehavior controller;
	bool isPickable = true;

	void Start ()
	{
		StartCoroutine (PleaseHold (7));
		GameObject controllerObject = GameObject.FindWithTag ("GameController");
		if (controllerObject != null) {
			controller = controllerObject.GetComponent<GameControllerBehavior> ();
		} else {
			Debug.Log ("Cannot find game controller...waa waa waaaaaaa");
		}
	}

	void OnMouseDown()
	{
		// Destroy entire tree on click
		if (isPickable) {
			Destroy (transform.parent.gameObject);
			controller.updateScore ();
		}
	}

	//HACK
	IEnumerator PleaseHold(int time) {
		yield return new WaitForSeconds(time);
		isPickable = false;
	}
}
