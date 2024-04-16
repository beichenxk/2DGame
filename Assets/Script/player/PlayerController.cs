using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

// public enum PlayerState
// {
//     Idle,
//     Jumping,
//     Falling,
//     Attacking,
//     Dead
// }



public class PlayerController : MonoBehaviour
{
    public Action onFlipSprite;
    // public PlayerState state;
    [Header("Property")]
    public static PlayerController instance;
    public Animator animator;
    public  Rigidbody2D rb;

    

    [Header("Move")]
    public float Speed;
    [HideInInspector]public bool moveRight;//用于判断是否向右,避免一直判定翻转函数FlipSprite
    // public float speed_x;
    // public float speed_y;

    public float JumpForce;
    void Awake()
    {
        instance=this;
        onFlipSprite+=flipSprite;
    }
    void OnValidate()
    {
        animator=GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerStateManager.instance.stateMachine.currentState.Update();//检测是否按键切换了状态
        // PlayerStateManager.instance.stateMachine.currentState.FixedUpdate();//检测是否按键切换了状态
    }




    public void ChangeAnimation(string animationName)
    {
        animator.CrossFade(animationName,0);
    }

    public void flipSprite()
    {

        if (moveRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // void FixedUpdate()
    // {
        // // 对刚体施力
        // speed_y-=9.8f*Time.deltaTime;
        // rb.velocity = new Vector2(speed_x, speed_y);
    // }

    // public void switchState(PlayerState state)
    // {
    //     this.state = state;

    //     switch (state)
    //     {
    //         case PlayerState.Idle:
    //             animator.SetBool("jump", false);
    //             break;
    //         case PlayerState.Jumping:
    //             animator.SetBool("jump", true);
    //             break;
    //         case PlayerState.Falling:
    //             break;
    //         case PlayerState.Attacking:
    //             break;
    //         case PlayerState.Dead:
    //             break;
    //         default:
    //             break;  
    //     }
    // }
}
