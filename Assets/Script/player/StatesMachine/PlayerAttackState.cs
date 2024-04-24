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
        if(!PlayerAnimationManager.instance.combo)
        {
            PlayerController.instance.ChangeAnimation("Fight_1");
        }
        else
        {
            PlayerController.instance.ChangeAnimation("Fight_2");
        }
        
        PlayerController.instance.rb.velocity=new Vector2(0,0);
    }
    public override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAnimationManager.instance.combo=true;
        }
    }
    
    public override void FixedUpdate()
    {
        
    }
    public override void Exit()
    {
        Debug.Log("end attack");
    }
}