using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class respawnpoint : MonoBehaviour
{
    void Awake()
    {
    }
    public void setRespawnPoint()
    {
        GetComponentInParent<spike>().respawnPoint=transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            setRespawnPoint();
        }
    }
}
