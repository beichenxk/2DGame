using System;
using Unity.Mathematics;
using UnityEngine;
public class PlayerDeadState : State
{
    public PlayerDeadState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Dead");
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
        Debug.Log("end Dead");
    }


}