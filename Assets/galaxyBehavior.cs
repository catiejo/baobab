using UnityEngine;
using System.Collections;

public class galaxyBehavior : MonoBehaviour 
{
//	private float _sensitivity;
//	private Vector3 _mouseReference;
//	private Vector3 _mouseOffset;
//	private Vector3 _rotation;
//	private bool _isRotating;
//
//	void Start ()
//	{
//		_sensitivity = 0.4f;
//		_rotation = Vector3.zero;
//	}
//
//	void Update()
//	{
//		if (Input.GetMouseButtonDown (0)) {
//			_isRotating = true;
//			_mouseReference = Input.mousePosition;
//		} else if (Input.GetMouseButtonUp (0)) {
//			_isRotating = false;
//		}
//
//		if(_isRotating)
//		{
//			// offset
//			_mouseOffset = (Input.mousePosition - _mouseReference);
//			// apply rotation
//			_rotation.y = -(_mouseOffset.x) * _sensitivity;
//			_rotation.x = (_mouseOffset.y) * _sensitivity;
//			// rotate
//			transform.Rotate(_rotation, relativeTo:Space.World);
//			// store mouse
//			_mouseReference = Input.mousePosition;
//		}
//	}

}