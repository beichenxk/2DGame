using System;
using Unity.Mathematics;
using UnityEngine;
public class PlayerCureState : State
{
    public PlayerCureState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Cure");
        PlayerController.instance.ChangeAnimation(name);
        AudioManager.instance.playPlayerSound((int)playerSoundtype.cure);
        if (DrinkChoose.instance.currentChoose == DrinkType.red)
        {
            if (PlayerData.instance.red >= 1)
            {
                PlayerData.instance.red--;
                PlayerData.instance.ChangeHealth(50);
            }
        }
        else
        {
            if (PlayerData.instance.blue >= 1)
            {
                PlayerData.instance.blue--;
                PlayerData.instance.ChangeMana(50);
            }
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
        Debug.Log("end Cure");
    }


}