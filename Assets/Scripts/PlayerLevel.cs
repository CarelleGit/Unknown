using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    //objects and bodies-------------------
    public GameObject spawner;

    //values-------------------------------
    public int level;
    public int exp;
    public int expLeft;
	// Use this for initialization
	void Start ()
    {
	
	}

    

    void levelUp(int exp)
    {
        var spawn = spawner.GetComponent<Spawner>();
        spawn.enemyCount = 0;
        spawn.spawnInt = (9/10) * spawn.spawnInt; //Number never reaches 0
    }

	// Update is called once per frame
	void Update ()
    {
		//Level up = current level * 1000;
        if(exp >= level * 1000)
        {
            levelUp(exp);
        }
        expLeft = (level * 1000) - exp; //how much is left before leveling, prints value to the screen.
         
	}
}
