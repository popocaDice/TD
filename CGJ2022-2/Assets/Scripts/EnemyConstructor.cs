using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstructor : MonoBehaviour
{
	public GameObject Enemy;
	public List<MobWave> Waves;

	private int waveIndex;

	private float lastSpawn;

    // Start is called before the first frame update
    void Start()
    {
		//InvokeRepeating("Birth", 0, 1);
		waveIndex = 0;
		Waves[waveIndex].listIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time > lastSpawn + Waves[waveIndex].spawnRate)
		{
			if (!Waves[waveIndex].Over())
			{
				Instantiate<GameObject>(Waves[waveIndex].enemies[Waves[waveIndex].listIndex]);
				Waves[waveIndex].listIndex++;
				lastSpawn = Time.time;
			}else if (Time.time > lastSpawn + Waves[waveIndex].waitTime)
			{
				waveIndex++;
				if (waveIndex == Waves.Count) Destroy(gameObject);
				Waves[waveIndex].listIndex = 0;
				lastSpawn = Time.time;
			}
		}
    }

	void Birth()
	{
		Instantiate<GameObject>(Enemy);
	}
}
