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
    public PlayerClimbState climbState;
    public PlayerCureState cureState;
    public PlayerRollState rollState;
    public PlayerAttackState attackState;
    public PlayerDeadState deadState;
    public PlayerPrepareShootState prepareShootState;
    public PlayerShootState shootState;



    void Awake()
    {
        instance=this;
        stateMachine = new StateMachine();
        idleState = new PlayerIdleState(stateMachine,"Idle");
        moveState = new PlayerMoveState(stateMachine,"Move");
        jumpState = new PlayerJumpState(stateMachine,"Jump");
        fallState = new PlayerFallState(stateMachine,"Fall");
        hangState = new PlayerHangState(stateMachine,"Hang");//应该改成悬挂动画
        climbState = new PlayerClimbState(stateMachine,"Idle");//应该改成攀爬动画
        cureState = new PlayerCureState(stateMachine,"Drink");
        rollState = new PlayerRollState(stateMachine,"Roll");
        attackState = new PlayerAttackState(stateMachine,"");
        deadState = new PlayerDeadState(stateMachine,"Dead");
        prepareShootState = new PlayerPrepareShootState(stateMachine,"");
        shootState = new PlayerShootState(stateMachine,"");
        stateMachine.Initialize(idleState);
    }

}

