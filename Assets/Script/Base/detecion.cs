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
    public bool isAtWall;
    public GameObject EdgeCheckPoint;
    public float distanceToEdge;
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
        Gizmos.DrawLine(GroundCheckPoint.transform.position, new Vector2(GroundCheckPoint.transform.position.x, GroundCheckPoint.transform.position.y - distanceToGround));
        Gizmos.DrawLine(WallCheckPoint.transform.position, new Vector2(WallCheckPoint.transform.position.x - distanceToWall * player.transform.localScale.x, WallCheckPoint.transform.position.y));
        Gizmos.DrawLine(EdgeCheckPoint.transform.position,new Vector2(EdgeCheckPoint.transform.position.x,EdgeCheckPoint.transform.position.y-distanceToEdge));
        // Gizmos.DrawLine(AttackCheckPoint.position,new Vector3(AttackCheckPoint.position.x+distanceOfAttack*transform.localScale.x,AttackCheckPoint.position.y));
    }
    public void checkAll()
    {
        GroundCheck();
        WallCheck();
        // EdgeCheck();
    }

    public void GroundCheck()
    {
        isAtGround = Physics2D.Raycast(GroundCheckPoint.transform.position, Vector2.down, distanceToGround, WhatIsGround);
    }
    public void WallCheck()
    {
        if(!PlayerController.instance.moveRight)
        {
            isAtWall = Physics2D.Raycast(WallCheckPoint.transform.position, Vector2.left,distanceToWall,WhatIsGround);
        }
        else
        {
            isAtWall = Physics2D.Raycast(WallCheckPoint.transform.position, Vector2.right, distanceToWall , WhatIsGround);
        }
        
    }
    
}
