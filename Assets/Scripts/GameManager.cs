using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject level;
    public GameObject player;
    public GameObject spawner;
    public GameObject enemy;

    public int enemyHealth;
    public int playerHealth;
    public float spawnRate;

    float timer;

    // Use this for initialization
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Controller>().health <= 0)
        {
            player.GetComponent<Controller>().death();
            spawner.GetComponent<Spawner>().restart();
            //enemy.GetComponent<EnemyController>().restart();
            for(int i = 0; i < spawner.GetComponent<Spawner>().listOfEnemies.Count; i++)
            {
                if (spawner.GetComponent<Spawner>().listOfEnemies[i] != null)
                {
                    Destroy(spawner.GetComponent<Spawner>().listOfEnemies[i]);
                    spawner.GetComponent<Spawner>().listOfEnemies.RemoveAt(i);
                    Debug.Log("Removed");
                }


            }
  
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                player.gameObject.SetActive(true);
                //enemy.SetActive(true);
                spawner.GetComponent<Spawner>().enemyCount = 0;
                spawner.gameObject.SetActive(true);
                enemy.gameObject.SetActive(true);
                level.GetComponent<PlayerLevel>().exp = 0;
                level.GetComponent<PlayerLevel>().level = 1;
                level.GetComponent<PlayerLevel>().expLeft = 1000;
                spawner.GetComponent<Spawner>().spawnInt = spawnRate;
                //enemy.GetComponent<EnemyController>().health = enemyHealth;
                player.GetComponent<Controller>().health = playerHealth;
                timer = 0;
            }
        }
    }
}
