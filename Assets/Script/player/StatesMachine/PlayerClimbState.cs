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
        if (Input.GetKey(KeyCode.A))
        {
            // Debug.Log("s");
            speed_x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Debug.Log("s");
            speed_x = 1;
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