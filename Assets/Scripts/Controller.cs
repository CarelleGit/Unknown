using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject weapon;
    public GameObject weapon2;

    //movement=================
    public float speed;
    public float airSpeed;
    public Rigidbody2D rb2;

    //jumping==================
    public float jump;
    public bool grounded;
    public Transform groundCheck;
    float radius = 0.2f;
    public LayerMask WhatGround;

    //Other====================
    public int health;
    public Slider healthBar;
    public Slider expBar;
    float timer;
    //Attacking================


    // Damage===================
    bool dead;
    bool damaged;

    //==================================================================================
    // Use this for initialization
    void Start()
    {
        if (weapon.GetComponent<SpriteRenderer>() != null && weapon.GetComponent<BoxCollider2D>() != null)
        {
            weapon.GetComponent<SpriteRenderer>().enabled = false;
            weapon.GetComponent<BoxCollider2D>().enabled = false;
        }
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radius, WhatGround);
    }
    //==================================================================================
    void Update()
    {
        var leveling = GetComponent<PlayerLevel>();
        //UI===================
        healthBar.value = health;
        expBar.value = leveling.exp;

        //Movement==============
        float horizontal = Input.GetAxis("Horizontal");


        Vector2 move = new Vector2(horizontal, 0);
        Vector2 desiredVelocity = move * speed * Time.deltaTime;
        rb2.velocity = new Vector2(desiredVelocity.x, rb2.velocity.y);
        if(Input.GetButton("Fire1"))
        {
            weapon2.GetComponent<SpriteRenderer>().enabled = true;
            weapon2.GetComponent<BoxCollider2D>().enabled = true;
            if (Input.GetButton("Fire2"))
            {
                weapon2.GetComponent<SpriteRenderer>().enabled = false;
                weapon2.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
            weapon2.GetComponent<SpriteRenderer>().enabled = false;
            weapon2.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (Input.GetButton("Fire2"))
        {
                weapon.GetComponent<SpriteRenderer>().enabled = true;
                weapon.GetComponent<BoxCollider2D>().enabled = true;
            if (Input.GetButton("Fire1"))
            {
                weapon.GetComponent<SpriteRenderer>().enabled = false;
                weapon.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        else
        {
                weapon.GetComponent<SpriteRenderer>().enabled = false;
                weapon.GetComponent<BoxCollider2D>().enabled = false;
        }
        //jumping===============
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2.AddForce(Vector2.up * jump);
            grounded = false;
        }
        if (grounded == false)
        {
            desiredVelocity = move * airSpeed * Time.deltaTime;
            rb2.velocity = new Vector2(desiredVelocity.x, rb2.velocity.y);
        }
    }
    //==================================================================================
   public void DamageTaken(int amount)
    {

        health -= amount;
        healthBar.value = health;
        if(health <= 0 && !dead)
        {
            death();
        }
    }
    //==================================================================================
    public void death()
    {
        gameObject.SetActive(false);
    }
}
