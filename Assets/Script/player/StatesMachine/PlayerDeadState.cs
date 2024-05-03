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
        // Debug.Log("enter Dead");
        PlayerController.instance.ChangeAnimation(name);
        PlayerController.instance.rb.velocity=Vector2.zero;
        AudioManager.instance.playPlayerSound((int)playerSoundtype.dead);
    }
    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        // Debug.Log("end Dead");
    }


}