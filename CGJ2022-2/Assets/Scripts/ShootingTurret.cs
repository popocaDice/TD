using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : MonoBehaviour
{
	public float damage, fireRate;

	private float count;

	private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
		enemies = new List<GameObject>();
    }

	private void FixedUpdate()
	{
		count = count>0?count-fireRate:0;
		if (count == 0)
		{
			Shoot();
		}
	}

	// Update is called once per frame
	void Update()
    {

    }

	void Shoot()
	{
		if (enemies.Count > 0)
		{
			enemies[0].GetComponent<EnemyPathfinding>().Damage(damage);
			count = 150;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		enemies.Add(collision.gameObject);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		enemies.Remove(collision.gameObject);
	}
}
