using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class PathingSpot : MonoBehaviour
{
	public List<GameObject> Paths;

	/*private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, 0.1f);

		foreach (GameObject spot in Paths)
		{
			Gizmos.DrawLine(transform.position, spot.transform.position);
		}
	}*/
}
