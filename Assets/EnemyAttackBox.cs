using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBox : MonoBehaviour
{
    public float atk;
    void Start()
    {
        atk=GetComponentInParent<enemyBase>().damage;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&&!PlayerData.instance.isInvincible)
        {
            PlayerData.instance.ChangeHealth(-(int)atk);
            PlayerAnimationManager.instance.Flash();
            AudioManager.instance.playPlayerSound((int)playerSoundtype.hurt);
        }
    }
}
