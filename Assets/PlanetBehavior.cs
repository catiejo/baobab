using UnityEngine;
using System.Collections;

public class PlanetBehavior : MonoBehaviour 
{
	public Transform baobab;
	int maxAttempts = 50;

	public void plantBaobab ()
	{
		int plantAttempts = 0;
		Vector3 emptySpot = Random.onUnitSphere * (0.45f);

		Transform newBaobab = Instantiate (baobab) as Transform;
		newBaobab.parent = gameObject.transform;
		while (plantAttempts < maxAttempts) {
			if (Physics.OverlapSphere (emptySpot, 0.45F).Length <= 1) {
				newBaobab.localPosition = emptySpot;
				// Position baobab to be facing center of planet
				newBaobab.LookAt(gameObject.transform.position);
				newBaobab.rotation = newBaobab.transform.rotation * Quaternion.Euler(-90, 0, 0); 
				return;
			}
			plantAttempts++;
			Debug.Log ("failed to plant baobab #" + plantAttempts);
		}
		Destroy (newBaobab.gameObject);
	}

}