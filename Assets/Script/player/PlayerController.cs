using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Jumping,
    Falling,
    Attacking,
    Dead
}



public class PlayerController : MonoBehaviour
{
    public PlayerState state;
    private Animator animator;
    Rigidbody2D rb ;

    public float speed_x;
    public float speed_y;
    private void Start()
    {
        animator=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case PlayerState.Idle:
                break;
            case PlayerState.Jumping:
                if (Input.GetKeyDown("space"))
                {
                    speed_y = 5;
                    speed_x = 0;
                }
                animator.SetBool("isJumping", true);//动画切换
                break;
            case PlayerState.Falling:
                break;
            case PlayerState.Attacking:
                break;
            case PlayerState.Dead:
                break;
            default:
                break;
        }
    }

    void FixedUpdate()
    {
        // 对刚体施力
        rb.velocity = new Vector2(speed_x, speed_y);
        
    }
}
