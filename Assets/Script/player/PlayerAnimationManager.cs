using UnityEngine;

public class PlayerAnimationManager:MonoBehaviour
{   
    public GameObject AttackBox;
     public void EnterIdleState()
    {
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
    }
    public void AttackStart()
    {
        AttackBox.SetActive(true);
    }
    public void AttackEnd()
    {
        AttackBox.SetActive(false);
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
    }
}