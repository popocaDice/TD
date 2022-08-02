using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
	public GameObject pathingFrom, pathingTo;

	public float max_speed, max_health;

	private Rigidbody2D rb2d;

	private float speed, health;
	private bool damage;

    // Start is called before the first frame update
    void Start()
    {
		speed = max_speed;
		health = max_health;

		pathingFrom = GameObject.FindGameObjectWithTag("Start");
		transform.position = pathingFrom.transform.position;
		pathingTo = pathingFrom.GetComponent<PathingSpot>().Paths[Random.Range(0, pathingFrom.GetComponent<PathingSpot>().Paths.Count)];

		rb2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
		rb2d.MovePosition(Vector2.MoveTowards(transform.position, pathingTo.transform.position, speed/100));

		if (health <= 0) Destroy(gameObject);
    }

	public void Damage(float d)
	{
		health -= d;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "End")
		{
			Destroy(gameObject);
		}

		if (collision.gameObject.layer == 6 && (collision.tag != "Start" || collision.tag != "End"))
		{
			pathingFrom = pathingTo;
			pathingTo = pathingFrom.GetComponent<PathingSpot>().Paths[Random.Range(0, pathingFrom.GetComponent<PathingSpot>().Paths.Count)];

		}
	}
}
