using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float normalPush = 10f;
    [SerializeField] float extraPush = 40f;

    bool bInitialPush;
    int pushCount;
    bool bPlayerDead;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (bPlayerDead) return;

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }
        else if(Input.GetAxisRaw("Horizontal") <0)
        {
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (bPlayerDead) return;


        if (!bInitialPush)
        {
            bInitialPush = true;
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, extraPush);
            collision.gameObject.SetActive(false);

            // Sound Manager
            return;   // Exit from the OnTriggerEnter
        }

        if (collision.tag == "NormalPush")
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, normalPush);
            collision.gameObject.SetActive(false);
            pushCount++;

        }

        if (collision.tag == "ExtraPush")
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, extraPush);
            collision.gameObject.SetActive(false);
            pushCount++;

        }

        if(pushCount==2)
        {
            pushCount = 0;
            PlatformSpawner.instance.SpawnPlatforms();
        }


    }
}
