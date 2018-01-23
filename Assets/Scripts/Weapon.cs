using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public LayerMask hit;
    public GameObject enemy;//Since we'll be encountering multiple enemies, this variable needs to automatically change itself;
        
    bool inRange;
    EnemyController control;
    // Use this for initialization
    void Start()
    {
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        // did I hit an enemy?
        // if so, deal damage!
        

        Debug.Log("Hit");


        // did I hit the enemy that I found at the beginning of the game?
        if (collision.gameObject.tag ==  "Enemy")
        {
            enemy = collision.gameObject;//Sets the enemy variable to the enemy game obj that we just hit
            control = enemy.GetComponent<EnemyController>();//gets the controller of the enemy we just hit.
            inRange = true;
        }
    }

     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            inRange = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       if(inRange && control.health > 0)
        {
            attack(damage);
        }
    }
    void attack(int damage)
    {
        if (control.health > 0)
        {
            control.DamageTaken(damage);
        }
    }
}
