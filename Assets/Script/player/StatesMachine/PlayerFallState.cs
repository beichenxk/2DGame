using UnityEngine;

public class PlayerFallState:State
{
 public PlayerFallState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Fall");
        PlayerController.instance.ChangeAnimation("Fall");
    }
    public override void Update()
    {
        if(Detection.instance.isAtGround)
        {
            stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
    }
    
    public override void FixedUpdate()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("end Fall");
    }
}