using UnityEngine;
using System.Collections;

public class PlanetBehavior : MonoBehaviour 
{
	public Transform baobab;

	public void plantBaobab ()
	{
		Transform newBaobab = Instantiate (baobab) as Transform;
		newBaobab.parent = gameObject.transform;
		newBaobab.localPosition = Random.onUnitSphere * (0.45f);
		// Position baobab to be facing center of planet
		newBaobab.LookAt(gameObject.transform.position);
		newBaobab.rotation = newBaobab.transform.rotation * Quaternion.Euler(-90, 0, 0);
	}

//	public bool plantBaobab ()
//	{
//		int plantAttempts = 0;
//		Vector3 emptySpot = Random.onUnitSphere * (0.5f);
//
//		Transform newBaobab = Instantiate (baobab) as Transform;
//		newBaobab.parent = gameObject.transform;
//		while (plantAttempts < maxAttempts) {
//			if (Physics.OverlapSphere (emptySpot, 5.0F).Length <= 1) {
//				newBaobab.localPosition = emptySpot;
//				// Position baobab to be facing center of planet
//				newBaobab.LookAt(gameObject.transform.position);
//				newBaobab.rotation = newBaobab.transform.rotation * Quaternion.Euler(-90, 0, 0); 
//				return true;
//			}
//			plantAttempts++;
//		}
//		return false;
//	}

}