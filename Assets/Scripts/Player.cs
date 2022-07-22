using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float normalPush = 10f;
    [SerializeField] float extraPush = 40f;

    bool bInitialPush;
    int pushCount;
    bool bPlayerDead;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExtraPush")
        {
            if(!bInitialPush)
            {
                bInitialPush = true;
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 18f);
                collision.gameObject.SetActive(false);
                // Sound Manager
                return;   // Exit from the OnTriggerEnter
            }
        }

    }
}
