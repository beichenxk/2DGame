using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            // Debug.Log("击中敌人");
            var enemyData=other.GetComponent<enemyBase>();
            enemyData.hp-=PlayerData.instance.atk;
            if(enemyData.hp<=0)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
