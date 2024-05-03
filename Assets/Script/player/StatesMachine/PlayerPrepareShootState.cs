using System;
using Unity.Mathematics;
using UnityEngine;
public class PlayerPrepareShootState : State
{
    

    public PlayerPrepareShootState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        // Debug.Log("enter prepare");
        PlayerController.instance.ChangeAnimation("Idle_fight");
        
    }
    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.shootState);
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

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        // Debug.Log("end prepare");
    }
    

}