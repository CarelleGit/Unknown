using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public float airSpeed;
    public Rigidbody2D rb2;
    public float jump;
    public bool grounded;
    public Transform groundCheck;
    float radius = 0.2f;
    public LayerMask WhatGround;
    // Use this for initialization
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radius, WhatGround);
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(horizontal, 0);
        Vector2 desiredVelocity = move * speed * Time.deltaTime;
        rb2.velocity = new Vector2(desiredVelocity.x, rb2.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb2.AddForce(Vector2.up * jump);
            grounded = false;
        }
        if(grounded == false)
        {
             desiredVelocity = move * airSpeed * Time.deltaTime;
            rb2.velocity = new Vector2(desiredVelocity.x, rb2.velocity.y);
        }
        
    }
}
