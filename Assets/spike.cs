using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spike : MonoBehaviour
{
    // public static spike instance;
    // public respawnpoint[] respawnpoints;
    public Vector3 respawnPoint;
    void Awake()
    {
        // respawnpoints=FindObjectsOfType<respawnpoint>();
        // instance=this;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //减少玩家血量;
            PlayerController.instance.rb.transform.position=respawnPoint;
            PlayerData.instance.ChangeHealth(-30);//需要删除
            AudioManager.instance.playPlayerSound((int)playerSoundtype.hurt);
            
        }
    }

}
