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
        animator=transform.parent.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case PlayerState.Idle:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    speed_y = 5;
                    speed_x = 0;
                    switchState(PlayerState.Jumping); 
                }
               
                break;
            case PlayerState.Jumping:
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
        speed_y-=9.8f*Time.deltaTime;
        rb.velocity = new Vector2(speed_x, speed_y);
    }

    public void switchState(PlayerState state)
    {
        this.state = state;

        switch (state)
        {
            case PlayerState.Idle:
                animator.SetBool("jump", false);
                break;
            case PlayerState.Jumping:
                animator.SetBool("jump", true);
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
}
