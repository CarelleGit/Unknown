using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float range;
    public float speed;
    public Transform player;
    public GameObject play;
    Transform myTransform;
   // public GameObject spawner;

    //Attack=======================
    bool playerInRange;
    public float timeBeforeAttack = 0.05f;
    Controller playerHealth;
    public int expRange;
    public int health;
    public int damage;
    float timer = 0;
    public int moneyGiven;

    //==================================================================================
    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
        play = Controller.instance.gameObject;
        playerHealth = Controller.instance;
    }
    //==================================================================================
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    //==================================================================================
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
    //==================================================================================
    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        player = go.transform;
    }
    //==================================================================================
    private void Update()
    {

        timer += Time.deltaTime;
        if(timer >= timeBeforeAttack && playerInRange && health > 0)
        {
            Attack();
        }

        Vector2 dir = player.position - myTransform.position;
        if (dir != Vector2.zero)
        {
           myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.FromToRotation(Vector2.right, dir), range * Time.deltaTime);
           
        }
        if (player.transform.position.x != transform.position.x)
        {
            myTransform.position += (player.position - myTransform.position).normalized * speed * Time.deltaTime;
        }
    }
    //==================================================================================
    void Attack()
    {
        timer = 0.0f;
        if (playerHealth.health > 0)
        {
            playerHealth.DamageTaken(damage);
        }
    }
    //==================================================================================
    public void restart()
    {
            gameObject.SetActive(false);
    }
    //==================================================================================
    public void DamageTaken(int amount)
    {
        
        health -= amount;
        if (health <= 0)
        {
            expRange = (int)Random.Range(expRange, expRange * 2);
            moneyGiven = (int)Random.Range(moneyGiven, moneyGiven * 2);
            var xp = play.GetComponent<PlayerLevel>();
            var mon = play.GetComponent<Controller>();

            mon.money += moneyGiven;
            xp.exp += expRange;
            
        }
    }
}

