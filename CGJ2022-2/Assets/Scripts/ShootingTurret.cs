using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootingTurret : MonoBehaviour
{
	public float damage, fireRate, detectionRange;

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
		Collider2D[] detectionList = Physics2D.OverlapCircleAll(transform.position, detectionRange, LayerMask.GetMask("Enemies"));
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

	void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, detectionRange);
	}

	/*private void OnTriggerEnter2D(Collider2D collision)
	{
		enemies.Add(collision.gameObject);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		enemies.Remove(collision.gameObject);
	}*/
}
