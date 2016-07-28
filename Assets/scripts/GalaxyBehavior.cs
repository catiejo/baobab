using UnityEngine;
using System.Collections;

public class GalaxyBehavior : MonoBehaviour 
{
	public float _sensitivity = 0.4f;
	private Vector3 _mouseReference;
	private Vector3 _mouseOffset;
	private Vector3 _rotation = Vector3.zero;
	private bool _isRotating;

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
			// Offset
			_mouseOffset = (Input.mousePosition - _mouseReference);
			// Apply rotation
			_rotation.y = -(_mouseOffset.x) * _sensitivity;
			_rotation.x = (_mouseOffset.y) * _sensitivity;
			transform.Rotate(_rotation, relativeTo:Space.World);
			// Store mouse position
			_mouseReference = Input.mousePosition;
		}
	}

}