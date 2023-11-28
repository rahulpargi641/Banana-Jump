using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;

    bool bFollowPlayer;
    [SerializeField] float minYTreshold = -2.6f;

    // Start is called before the first frame update
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (target.position.y < transform.position.y - minYTreshold)
        {
            bFollowPlayer = false;
        }

        if(target.position.y > transform.position.y)
        {
            bFollowPlayer = true;

            if (bFollowPlayer)
            { 
                Vector3 temp = transform.position;
                temp.y = target.position.y;
                transform.position = temp;
            }
        }
    }
}
