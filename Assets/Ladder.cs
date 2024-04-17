using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool canClimb;

    void Update()
    {
        if(canClimb)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.climbState); 
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClimb=true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canClimb=false;
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        }
    }
}
