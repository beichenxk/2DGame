using System;
using Unity.Mathematics;
using UnityEngine;
public class PlayerShootState : State
{
    public PlayerShootState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter shoot");
        PlayerController.instance.ChangeAnimation("Shoot");
    }
    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        Debug.Log("end shoot");
    }


}