using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{

    //objects and bodies-------------------
    public GameObject spawner;

    //values-------------------------------
    public int level;
    public int exp;
    public int expLeft;

    //Other================================
    public Text LV;
	// Use this for initialization
	void Start ()
    {
       
	}

    

    void levelUp(int exp)
    {
        //var spawn = spawner.GetComponent<Spawner>();
        level++;
        spawner.GetComponent<Spawner>().enemyCount = 0;
        float desiredSpawnInt = (9f / 10f) * spawner.GetComponent<Spawner>().spawnInt;
        spawner.GetComponent<Spawner>().spawnInt = desiredSpawnInt; //Number never reaches 0

    }

	// Update is called once per frame
	void Update ()
    {
		//Level up = current level * 1000;
        if(exp >= level * 1000)
        {
            levelUp(exp);
            exp = 0;
        }
        expLeft = (level * 1000) - exp; //how much is left before leveling, prints value to the screen.
        LV.text = "LV: " + level.ToString();
    }
}
