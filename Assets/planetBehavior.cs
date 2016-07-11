using UnityEngine;
using System.Collections;

public class planetBehavior : MonoBehaviour 
{
	public Transform baobab;

	void Start ()
	{
		Debug.Log("starting");
		InvokeRepeating("plantBaobab", 0, 5F);
	}

	void plantBaobab ()
	{
		Transform newBaobab = Instantiate (baobab) as Transform;
		newBaobab.parent = gameObject.transform;
		newBaobab.localPosition = Random.onUnitSphere * (0.6f + newBaobab.localScale.y * 0.5f);
		newBaobab.LookAt(gameObject.transform.position);
		newBaobab.rotation = newBaobab.transform.rotation * Quaternion.Euler(-90, 0, 0);
	}

}