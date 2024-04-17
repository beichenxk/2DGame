using UnityEngine;

public class PlayerFallState : State
{
    public static PlayerFallState instance;
    private float speed_x;


    public PlayerFallState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }
    void Awake()
    {
        instance=this;
        detection.instance.canGrab=true;
    }
    public override void Enter()
    {
        Debug.Log("enter Fall");
        PlayerController.instance.ChangeAnimation(name);
    }
    public override void Update()
    {
        if (detection.instance.isAtGround)
        {
            // Debug.Log(1);
            stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
        if(!detection.instance.isAtEdge)
        {
            // Debug.Log(2);
            detection.instance.canGrab=true;
        }
        if (detection.instance.isAtEdge&&detection.instance.canGrab)
        {
            // Debug.Log(3);
            detection.instance.canGrab=false;
            stateMachine.ChangeState(PlayerStateManager.instance.hangState);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("fall a");
            speed_x = -PlayerController.instance.Speed;

            if (PlayerController.instance.moveRight == true)
            {
                PlayerController.instance.moveRight = false;
                PlayerController.instance.onFlipSprite();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("fall d");
            speed_x = PlayerController.instance.Speed;
            if (PlayerController.instance.moveRight == false)
            {
                PlayerController.instance.moveRight = true;
                PlayerController.instance.onFlipSprite();
            }
        }
        else
        {
            speed_x = 0;
            PlayerController.instance.rb.velocity = new Vector2(speed_x, PlayerController.instance.rb.velocity.y);
        }
    }

    public override void FixedUpdate()
    {
        PlayerController.instance.rb.velocity = new Vector2(speed_x, PlayerController.instance.rb.velocity.y);
    }
    public override void Exit()
    {
        Debug.Log("end Fall");
    }

}