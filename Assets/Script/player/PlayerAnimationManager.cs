using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationManager:MonoBehaviour
{   
    public static PlayerAnimationManager instance;
    void Awake()
    {
        instance=this;
    }

    public void EnterIdleState()
    {
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
    }
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
    public GameObject AttackBox;
    public bool combo=false;
    public void AttackStart()
    {
        AttackBox.SetActive(true);
    }
    public void AttackEnd()
    {
        AttackBox.SetActive(false);
        if(!combo)
        {
            Debug.Log("进入空闲");
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
        else if(combo)
        {
            Debug.Log("进入连击");
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.attackState);
        }
        
    }
    public void ComboEnd()
    {
        EnterIdleState();
        combo=false;
    }
    public void DeadEnd()
    {
        LevelManager.instance.respawn();
    }
}