using UnityEngine;
using System.Collections;

public class BaobabTopBehavior : MonoBehaviour {

	void OnMouseDown()
	{
		Destroy (transform.parent.gameObject);
	}
}
