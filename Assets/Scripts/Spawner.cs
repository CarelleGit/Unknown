using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnInt; 
    public float range;
    float timer;
    public int limit;
    public int enemyCount = 0;
    // Use this for initialization
    void Start ()
    {
		
	}
	void enemies()
    {
        enemyCount += 1;
        if (enemyCount <= limit)
        {
            GameObject spawnEnemy = Instantiate(enemy);
            float ranX = Random.Range(-range, range);
            spawnEnemy.transform.position = transform.position + new Vector3(ranX, 0, 0);
        }
    }
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            enemies();
            timer = spawnInt;
        }
	}
}
