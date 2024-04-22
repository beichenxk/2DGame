using UnityEngine;


public class PlayerAttackState:State
{
    public object Inputnput { get; private set; }

    public PlayerAttackState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Attack");
        PlayerController.instance.ChangeAnimation(name);
        PlayerController.instance.rb.velocity=new Vector2(0,0);
    }
    public override void Update()
    {
    }
    
    public override void FixedUpdate()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("end attack");
    }
}