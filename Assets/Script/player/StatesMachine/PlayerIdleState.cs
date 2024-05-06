using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;


public class PlayerIdleState : State
{
    public PlayerIdleState(StateMachine stateMachine, string Name) : base(stateMachine, Name)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter idle");
        PlayerController.instance.ChangeAnimation(name);
        PlayerController.instance.rb.velocity=new Vector2(0,PlayerController.instance.rb.velocity.y);
        
    }
    public override void Update()
    {
        if (!detection.instance.isAtGround)
        {
            stateMachine.ChangeState(PlayerStateManager.instance.fallState);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)&&Utility.instance.canAttack)
        {
            // Debug.Log("进入攻击");
            stateMachine.ChangeState(PlayerStateManager.instance.attackState);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.prepareShootState);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.moveState);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.moveState);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
                PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.cureState);
        }


    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    public override void Exit()
    {
        Debug.Log("end idle");
    }
}