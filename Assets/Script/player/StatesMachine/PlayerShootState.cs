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
        // Debug.Log("enter shoot");
        if(!PlayerAnimationManager.instance.chargeShoot)
        {
            AudioManager.instance.playPlayerSound((int)playerSoundtype.shoot);
            PlayerController.instance.ChangeAnimation("Shoot");
            PlayerController.instance.shoot();
        }
        else
        {
            AudioManager.instance.playPlayerSound((int)playerSoundtype.chargeShoot);
            PlayerController.instance.ChangeAnimation("Shoot");
        }

        
        
    }
    public override void Update()
    {
    }

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        // Debug.Log("end shoot");
    }


}