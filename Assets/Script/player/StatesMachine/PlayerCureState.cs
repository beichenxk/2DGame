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
        PlayerData.instance.red--;
        PlayerData.instance.currentHP=Math.Clamp(PlayerData.instance.currentHP+50,0,PlayerData.instance.maxHp);
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