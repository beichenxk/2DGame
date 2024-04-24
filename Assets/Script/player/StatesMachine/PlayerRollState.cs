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
        if (PlayerController.instance.transform.localScale.x == 1)
        {
            PlayerController.instance.rb.velocity = new Vector2(-3, PlayerController.instance.rb.velocity.y);
        }
        else
        {
        PlayerController.instance.rb.velocity = new Vector2(3, PlayerController.instance.rb.velocity.y);

        }
    }
    public override void Exit()
    {
        Debug.Log("end Roll");
        PlayerController.instance.rb.velocity = new Vector2(0, PlayerController.instance.rb.velocity.y);
    }


}