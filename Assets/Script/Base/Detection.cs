using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public static Detection instance;
    public GameObject GroundCheckPoint;
    public float distanceToGround;
    public bool isAtGround;
    public LayerMask WhatIsGround;

    void OnValidate()
    {
        instance=this;
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheckPoint.transform.position, new Vector3(GroundCheckPoint.transform.position.x, GroundCheckPoint.transform.position.y - distanceToGround));
        // Gizmos.DrawLine(transform.position,new Vector3(transform.position.x+distanceToWall*transform.localScale.x,transform.position.y));
        // Gizmos.DrawLine(AttackCheckPoint.position,new Vector3(AttackCheckPoint.position.x+distanceOfAttack*transform.localScale.x,AttackCheckPoint.position.y));
    }

    public  void GroundCheck()
    {
        isAtGround = Physics2D.Raycast(GroundCheckPoint.transform.position, Vector2.down, distanceToGround, WhatIsGround);
    }
}
