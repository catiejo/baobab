using UnityEngine;
using System.Collections;

public class planetBehavior : MonoBehaviour 
{
	public Transform baobab;
	private float _sensitivity;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation;
	private bool _isRotating;

	void Start ()
	{
		_sensitivity = 0.4f;
		_rotation = Vector3.zero;
		Debug.Log("starting");
		InvokeRepeating("plantBaobab", 0, 5F);
	}

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) {
			_isRotating = true;
			_mouseReference = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			_isRotating = false;
		}

		if(_isRotating)
		{
			// offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			// apply rotation
			_rotation.y = -(_mouseOffset.x) * _sensitivity;
			_rotation.x = (_mouseOffset.y) * _sensitivity;
			// rotate
			transform.Rotate(_rotation, relativeTo:Space.World);
			// store mouse
			_mouseReference = Input.mousePosition;
		}
	}

	void plantBaobab ()
	{
		Debug.Log("baobab");
		Vector3 spawnPosition = Random.onUnitSphere * ((gameObject.transform.localScale.x / 2) + baobab.transform.localScale.y * 0.5f) + gameObject.transform.position;
		Transform newBaobab = Instantiate (baobab, spawnPosition, Quaternion.identity) as Transform;
		newBaobab.gameObject.transform.parent = gameObject.transform;
	}

}