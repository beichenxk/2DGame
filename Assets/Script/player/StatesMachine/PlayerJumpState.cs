using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJumpState : State
{
    private float speed_x;
    public PlayerJumpState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }
    public override void Enter()
    {
        Debug.Log("enter Jump");
        PlayerController.instance.ChangeAnimation(name);
        PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.rb.velocity.x, PlayerController.instance.JumpForce);
    }
    public override void Update()
    {
        if ((PlayerController.instance.rb.velocity.y - 0) < 0.001f)
        {
            stateMachine.ChangeState(PlayerStateManager.instance.fallState);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed_x = -PlayerController.instance.Speed;

            if (PlayerController.instance.moveRight == true)
            {
                PlayerController.instance.moveRight = false;
                PlayerController.instance.onFlipSprite();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed_x = PlayerController.instance.Speed;
            if (PlayerController.instance.moveRight == false)
            {
                PlayerController.instance.moveRight = true;
                PlayerController.instance.onFlipSprite();
            }
        }
        else
        {
            speed_x=0;
            PlayerController.instance.rb.velocity = new Vector2(speed_x, PlayerController.instance.rb.velocity.y);
        }
    }

    public override void FixedUpdate()
    {
         PlayerController.instance.rb.velocity = new Vector2(speed_x, PlayerController.instance.rb.velocity.y);
    }
    public override void Exit()
    {
        Debug.Log("end Jump");
    }
}