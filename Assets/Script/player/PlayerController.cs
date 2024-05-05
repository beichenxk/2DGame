using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public class PlayerController : MonoBehaviour
{
    public Action onFlipSprite;
    // public PlayerState state;
    [Header("Property")]
    public static PlayerController instance;
    public Animator animator;
    public Rigidbody2D rb;
    public detection detection;
    public bool canMove;
    [Header("shoot")]
    public Transform firepoint;
    public GameObject bulletPrefab;
    public bool charge;






    [Header("Move")]
    public float Speed;
    [HideInInspector] public bool moveRight;//用于判断是否向右,避免一直判定翻转函数FlipSprite

    public float JumpForce;
    public float ClimbSpeed;

    void Awake()
    {
        instance = this;
        onFlipSprite += flipSprite;
        canMove = true;
    }
    void OnValidate()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        detection = GetComponentInChildren<detection>();

    }

    // Update is called once per frame
    void Update()
    {
        detection.checkAll();
        if (canMove == true)
        {
            PlayerStateManager.instance.stateMachine.currentState.Update();
            PlayerStateManager.instance.stateMachine.currentState.FixedUpdate();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // PlayerData.instance.ChangeHealth(-10);
            // PlayerData.instance.ChangeMana(-10);
        }



    }
    void FixedUpdate()
    {
        PlayerStateManager.instance.stateMachine.currentState.FixedUpdate();//检测是否按键切换了状态
    }




    public void ChangeAnimation(string animationName)
    {
        animator.CrossFade(animationName, 0);
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

    public void shoot(bool charge=false)
    {
        var bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        if (charge)
        {
            bullet.transform.localScale = 2 * transform.localScale;
        }
        else
        {
            bullet.transform.localScale = transform.localScale;
        }
        AudioManager.instance.playPlayerSound((int)playerSoundtype.shoot);
    }
}
