using UnityEngine;


public class PlayerMoveState : State
{
    float speed_x;
    public PlayerMoveState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter move");
        PlayerController.instance.ChangeAnimation(name);
    }

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&Utility.instance.canAttack)
        {
            stateMachine.ChangeState(PlayerStateManager.instance.attackState);
        }
        else if (!detection.instance.isAtGround)
        {
            stateMachine.ChangeState(PlayerStateManager.instance.fallState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.rollState);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            speed_x = -PlayerController.instance.Speed;

            if (PlayerController.instance.moveRight == true)
            {
                PlayerController.instance.moveRight = false;
                PlayerController.instance.onFlipSprite();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed_x = PlayerController.instance.Speed;
            if (PlayerController.instance.moveRight == false)
            {
                PlayerController.instance.moveRight = true;
                PlayerController.instance.onFlipSprite();
            }
        }


        //什么都不输入时,转为静止状态
        else
        {
            PlayerController.instance.rb.velocity = new Vector2(0, PlayerController.instance.rb.velocity.y);
            stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
    }
    public override void FixedUpdate()
    {

        PlayerController.instance.rb.velocity = new Vector2(speed_x, PlayerController.instance.rb.velocity.y);

    }
    public override void Exit()
    {
        Debug.Log("end move");
    }
}