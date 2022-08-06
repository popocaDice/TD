using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobWave : MonoBehaviour
{
	public List<GameObject> enemies;
	public int listIndex;
	public float spawnRate, waitTime;

	public bool Over()
	{
		return listIndex == enemies.Count;
	}
}
