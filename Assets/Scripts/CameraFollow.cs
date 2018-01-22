using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    void LateUpdate()
    {
        //transform.position = new Vector3(player.transform.position.x, 0f, -10f);
        if (player.transform.position.x > 0f && player.transform.position.x < 10f)
        {
            transform.position = new Vector3(player.transform.position.x, 0f, -10f);
        }
    }
}

