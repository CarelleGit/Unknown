using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb2;
    public float jump;
   public GameObject ground;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 move = new Vector2(horizontal, 0);
        Vector2 desiredVelocity = move * speed * Time.deltaTime;
        rb2.velocity = new Vector2(desiredVelocity.x, rb2.velocity.y);
        if(Input.GetButtonDown("Jump"))
        {
            if (ground)
            {
                rb2.AddForce(Vector2.up * jump);
            }
        }
	}
}
