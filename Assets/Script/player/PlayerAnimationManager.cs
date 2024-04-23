using UnityEngine;

public class PlayerAnimationManager:MonoBehaviour
{   
    public GameObject AttackBox;
     public void ChangeRollState()
    {
        if(detection.instance.isAtWall)
        {
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.rollState);
        }
        else
        {
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
        
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
    public void DeadEnd()
    {
        LevelManager.instance.respawn();
    }
}