using UnityEngine;

public class PlayerAnimationManager:MonoBehaviour
{
     public void EnterIdleState()
    {
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
    }
}