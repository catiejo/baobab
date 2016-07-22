using UnityEngine;
using System.Collections;

public class PlanetBehavior : MonoBehaviour 
{
	public Transform baobab;

	int maxAttempts = 50;

	public void plantBaobab ()
	{
		int plantAttempts = 0;
		Vector3 emptySpot = Random.onUnitSphere * (0.5f);

		while (plantAttempts < maxAttempts) {
			//This OverlapSphere isn't working...why?
			if (Physics.OverlapSphere (transform.TransformPoint(emptySpot), 0.3F).Length <= 1) {
				Transform newBaobab = Instantiate (baobab) as Transform;
				newBaobab.parent = gameObject.transform;
				newBaobab.localPosition = emptySpot;
				// Position baobab to be facing center of planet
				newBaobab.LookAt(gameObject.transform.position);
				newBaobab.rotation = newBaobab.transform.rotation * Quaternion.Euler(-90, 0, 0); 
				return;
			}
			emptySpot = Random.onUnitSphere * (0.5f);
			plantAttempts++;
		}
		Debug.Log ("failed to plant baobab");
	}

}