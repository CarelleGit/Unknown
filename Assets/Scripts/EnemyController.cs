using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float range;
    public float speed;
    public Transform player;
    Transform myTransform;
    // Use this for initialization
    void Awake()
    {
        myTransform = transform;
    }

    private void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        player = go.transform;
    }
    private void Update()
    {


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
}

