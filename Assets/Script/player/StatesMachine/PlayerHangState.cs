using UnityEngine;


public class PlayerHangState:State
{
    public object Inputnput { get; private set; }

    public PlayerHangState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Hang");
        PlayerController.instance.ChangeAnimation(name);
        PlayerController.instance.rb.gravityScale=0;
        PlayerController.instance.rb.velocity=Vector2.zero;
    }
    public override void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.instance.rb.gravityScale=1;
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            detection.instance.canGrab=false;
            PlayerController.instance.rb.gravityScale=1;
            stateMachine.ChangeState(PlayerStateManager.instance.fallState);
        }
    }
    
    public override void FixedUpdate()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("end Hang");
    }
}