using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spike : MonoBehaviour
{
    public GameObject respawnPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //减少玩家血量;
            PlayerController.instance.rb.transform.position=respawnPoint.transform.position;
        }
    }
}
