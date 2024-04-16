using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerIdleState : State
{
    public PlayerIdleState(StateMachine stateMachine, string Name) : base(stateMachine, Name)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter idle");
        PlayerController.instance.ChangeAnimation("Idle");
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.moveState);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.moveState);

        }

    }
    public override void Exit()
    {
        Debug.Log("end idle");
    }
}