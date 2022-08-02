using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstructor : MonoBehaviour
{
	public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("Birth", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

	void Birth()
	{
		Instantiate<GameObject>(Enemy);
	}
}
