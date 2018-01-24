using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{

    //objects and bodies-------------------
    public GameObject spawner;
    public GameObject enemy;
    public GameObject player;
    public GameObject weapon;
    //values-------------------------------
    public int level;
    int xpNeeded = 1000;
    public int exp;
    public int expLeft;
    int newValue = 0;
    //Other================================
    public Text LV;
    public Text HP;
    public Text DP;
    public Text XP;

    public Slider expSlider;
    public Slider HPslider;
    // Use this for initialization
    void Start()
    {

    }



    void levelUp(int exp)
    {
        //var spawn = spawner.GetComponent<Spawner>();
        level++;
        spawner.GetComponent<Spawner>().enemyCount = 0;
        float desiredSpawnInt = (9f / 10f) * spawner.GetComponent<Spawner>().spawnInt;
        enemy.GetComponent<EnemyController>().health += 10;
        enemy.GetComponent<EnemyController>().damage += 6;
        player.GetComponent<Controller>().totalHealth += 20;
        spawner.GetComponent<Spawner>().spawnInt = desiredSpawnInt; //Number never reaches 0
        //expSlider.maxValue = level * 1000;

    }

    // Update is called once per frame
    void Update()
    {
        //Level up = current level * 1000;
        if (exp >= level * 1000)
        {
            levelUp(exp);
            xpNeeded = level * 1000;
            exp = 0;
        }
        expLeft = (level * 1000) - exp; //how much is left before leveling, prints value to the screen.
        LV.text = "LV: " + level.ToString();
        
            HP.text = "HP: " + player.GetComponent<Controller>().health + "/" + player.GetComponent<Controller>().totalHealth;
            DP.text = "DP: " + weapon.GetComponent<Weapon>().damage;
            XP.text = "EXP: " + exp + "/" + xpNeeded;
        
        HPslider.maxValue = player.GetComponent<Controller>().totalHealth;
        expSlider.maxValue = level * 1000;
    }
}
