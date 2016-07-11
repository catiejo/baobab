using UnityEngine;
using System.Collections;

public class BaobabTopBehavior : MonoBehaviour {

	void OnMouseDown()
	{
		// Destroy entire tree on click
		Destroy (transform.parent.gameObject);
	}
}
