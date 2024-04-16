using UnityEngine;


public class PlayerMoveState : State
{
    public PlayerMoveState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }


    public override void Enter()
    {
        Debug.Log("enter move");
        PlayerController.instance.ChangeAnimation("Move");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(PlayerStateManager.instance.jumpState);
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerController.instance.rb.velocity = new Vector2(-PlayerController.instance.Speed, PlayerController.instance.rb.velocity.y);
            if (PlayerController.instance.moveRight == true)
            {
                PlayerController.instance.moveRight = false;
                PlayerController.instance.onFlipSprite();
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.Speed, PlayerController.instance.rb.velocity.y);
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
    // public override void FixedUpdate()
    // {


    // }
    public override void Exit()
    {
        Debug.Log("end move");
    }
}