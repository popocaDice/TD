using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Guitarrista : MonoBehaviour
{
	public float damage, fireRate, detectionRange, detectionWidth;

	private float count;

	private List<GameObject> enemies;
	private Collider2D[] detectionList;

	// Start is called before the first frame update
	void Start()
	{
		enemies = new List<GameObject>();
	}

	private void FixedUpdate()
	{
		if (Input.GetMouseButtonDown(1))
		{
			transform.Rotate(Vector3.forward, 90);
		}
	}

	// Update is called once per frame
	void Update()
	{
		count = count > 0 ? count - fireRate : 0;
		//Collider2D[] detectionList = Physics2D.OverlapCircleAll(transform.position, detectionRange, LayerMask.GetMask("Enemies"));
		detectionList = Physics2D.OverlapBoxAll(transform.position + Vector3.up * (detectionRange / 2), new Vector2(detectionWidth, detectionRange), transform.rotation.eulerAngles.z, LayerMask.GetMask("Enemies"));
		foreach (GameObject enemy in enemies.ToList())
		{
			if (enemy == null)
			{
				enemies.Remove(enemy);
			}
			else if (!detectionList.Contains(enemy.GetComponent<Collider2D>()))
			{
				enemies.Remove(enemy);
			}
		}
		foreach (Collider2D enemy in detectionList)
		{
			if (!enemies.Find(o => o == enemy.gameObject))
			{
				enemies.Add(enemy.gameObject);
			}
		}
		if (count == 0)
		{
			Shoot();
		}
	}

	void Shoot()
	{
		if (enemies.Count > 0)
		{
			enemies[0].GetComponent<EnemyPathfinding>().Damage(damage);
			count = 150;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(Vector3.up * (detectionRange/2), new Vector3(detectionWidth, detectionRange));
	}

	
}
