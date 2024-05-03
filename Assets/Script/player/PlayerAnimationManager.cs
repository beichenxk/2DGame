using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public static PlayerAnimationManager instance;
    public float FlashTime;
    public SpriteRenderer theSR;
    private int rollCount=0;
    public GameObject AttackBox;
    public bool combo = false;

    public bool chargeShoot;

    void Awake()
    {
        instance = this;
        theSR = GetComponent<SpriteRenderer>();
    }

    public void EnterIdleState()
    {
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
    }

    public void startRoll()
    {
        PlayerData.instance.isInvincible=true;
    }
    public void ChangeRollState()
    {
        PlayerData.instance.isInvincible=false;
        
        if (detection.instance.isAtWall&&rollCount!=1)
        {
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.rollState);
            rollCount++;
        }
        else
        {
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
            rollCount=0;
        }

    }
    
    public void AttackStart()
    {
        AttackBox.SetActive(true);
    }
    public void AttackEnd()
    {
        AttackBox.SetActive(false);
        if (!combo)
        {
            // Debug.Log("进入空闲");
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
        else if (combo)
        {
            // Debug.Log("进入连击");
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.attackState);
        }

    }
    public void ComboEnd()
    {
        EnterIdleState();
        combo = false;
    }
    public void DeadEnd()
    {
        LevelManager.instance.respawn();
    }

    public void Flash()
    {
        StartCoroutine(FlashCo());
    }

    IEnumerator FlashCo()
    {
        for (int i = 0; i < FlashTime * 2; i++)
        {
            theSR.color = new Vector4(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(.25f);
            theSR.color = new Vector4(1, 1, 1, 1);
            yield return new WaitForSeconds(.25f);
        }
    }

    public void becomeInvincible()
    {
        PlayerData.instance.isInvincible=PlayerData.instance.isInvincible?false:true;
    }

    public void startResurrection()
    {
        AudioManager.instance.playPlayerSound((int)playerSoundtype.Resurrection);
    }
    public void ShootEnd()
    {
        if(!PlayerController.instance.charge)
        {
            EnterIdleState();
        }
    }
 
}