using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    public static detection instance;
    public GameObject GroundCheckPoint;
    public float distanceToGround;
    public bool isAtGround;


    public GameObject WallCheckPoint;
    public float distanceToWall;
    public bool isAtEdge;
    public LayerMask WhatIsGround;
    public bool canGrab;

    void Awake()
    {
        instance = this;
        player = GetComponentInParent<PlayerController>();
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheckPoint.transform.position, new Vector3(GroundCheckPoint.transform.position.x, GroundCheckPoint.transform.position.y - distanceToGround));
        Gizmos.DrawLine(WallCheckPoint.transform.position, new Vector3(WallCheckPoint.transform.position.x - distanceToWall * player.transform.localScale.x, WallCheckPoint.transform.position.y));
        // Gizmos.DrawLine(AttackCheckPoint.position,new Vector3(AttackCheckPoint.position.x+distanceOfAttack*transform.localScale.x,AttackCheckPoint.position.y));
    }

    public void GroundCheck()
    {
        isAtGround = Physics2D.Raycast(GroundCheckPoint.transform.position, Vector2.down, distanceToGround, WhatIsGround);
    }
    public void EdgeCheck()
    {
        if(!PlayerController.instance.moveRight)
        {
            isAtEdge = Physics2D.Raycast(WallCheckPoint.transform.position, Vector2.left,distanceToWall,WhatIsGround);
        }
        else
        {
            isAtEdge = Physics2D.Raycast(WallCheckPoint.transform.position, Vector2.right, distanceToWall , WhatIsGround);
        }
        
    }
}
