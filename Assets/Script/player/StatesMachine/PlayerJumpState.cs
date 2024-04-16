using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJumpState : State
{

    public PlayerJumpState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public void Update()
    {
        if ((PlayerController.instance.rb.velocity.y - 0) < 1f)
        {
            stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
    }
    public override void Enter()
    {
        Debug.Log("enter Jump");
        PlayerController.instance.ChangeAnimation("Jump");
        PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.rb.velocity.x, PlayerController.instance.JumpForce);
    }
    // public override void FixedUpdate()
    // {
        
    // }
    public override void Exit()
    {
        Debug.Log("end Jump");
    }
}