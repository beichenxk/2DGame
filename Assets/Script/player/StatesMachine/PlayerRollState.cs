using System;
using Unity.Mathematics;
using UnityEngine;
public class PlayerRollState : State
{
    public PlayerRollState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Roll");
        PlayerController.instance.ChangeAnimation(name);
    }
    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        Debug.Log("end Roll");
        PlayerController.instance.rb.velocity=new Vector2(0,PlayerController.instance.rb.velocity.y);
    }

   
}