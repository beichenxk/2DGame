using UnityEngine;

public class PlayerStateManager:MonoBehaviour
{
    public static PlayerStateManager instance;
    [Header("stateMachine")]
    public StateMachine stateMachine;

    public PlayerIdleState idleState;
    public PlayerMoveState moveState;
    public PlayerJumpState jumpState;
    public PlayerFallState fallState;
    public PlayerHangState hangState;



    void Awake()
    {
        instance=this;
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(stateMachine,"Idle");
        moveState = new PlayerMoveState(stateMachine,"Move");
        jumpState = new PlayerJumpState(stateMachine,"Jump");
        fallState = new PlayerFallState(stateMachine,"Fall");
        hangState = new PlayerHangState(stateMachine,"Idle");
        stateMachine.Initialize(idleState);
    }

}

