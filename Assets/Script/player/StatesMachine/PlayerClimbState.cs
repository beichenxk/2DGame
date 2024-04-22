using UnityEngine;


public class PlayerClimbState : State
{
    private float speed_y;
    private float speed_x;
    public PlayerClimbState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        Debug.Log("enter Climb");
        PlayerController.instance.ChangeAnimation(name);
        PlayerController.instance.rb.gravityScale = 0;
        PlayerController.instance.rb.velocity = Vector2.zero;
    }
    public override void Update()
    {   
        speed_x = 0;
        speed_y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            // Debug.Log("w");
            speed_y = PlayerController.instance.ClimbSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Debug.Log("s");
            speed_y = -PlayerController.instance.ClimbSpeed;
        }
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.A))
        {
            PlayerController.instance.rb.velocity=new Vector2(PlayerController.instance.Speed,0);
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Debug.Log("s");
            PlayerController.instance.rb.velocity=new Vector2(-PlayerController.instance.Speed,0);
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        }
        
       
            

    }

    public override void FixedUpdate()
    {
        PlayerController.instance.rb.velocity = new Vector2(speed_x, speed_y);
    }
    public override void Exit()
    {
        Debug.Log("end climb");
        PlayerController.instance.rb.gravityScale = 1;
    }
}