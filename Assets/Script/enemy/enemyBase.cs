using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyBase : MonoBehaviour
{
    public string enemyName = "enemy";
    public int exp = 1; 
    public float speed = 1;//敌人移动速度
    public bool moveRight = true; //敌人是否向右移动
    public float lastAttackTime = float.MinValue;
    public float attackCD = 1;
    public float hp = 100;
    public float damage = 10;
    public float Range = 0; //索敌距离
    //public float nearRange = 1; //近战索敌距离
    public bool isStop=false; //敌人是否停止移动
    public bool isInCamera = false; //是否在摄像机视野中


    public virtual void checkInCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x > 0 && pos.x < 1 && pos.y > 0 && pos.y < 1)
        {
            isInCamera = true;
        }
        else
        {
            isInCamera = false;
        }
    }


    public virtual bool InRange()
    {
        GameObject player = GameObject.Find("Sprite");
        
        float x=player.transform.position.x;
        float distance=Math.Abs(x-transform.position.x);
        //Debug.LogError("distance:"+distance);
        
        if (x > transform.position.x && moveRight)
        {
            if (distance < Range)
                return true;
        }else if (x < transform.position.x && !moveRight)
        {
            if (distance < Range)
                return true;
        }
            return false;
    }

    public virtual void moveOrAttack()
    {
        if (!isStop)
        {
            if (moveRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
        else
        {
            if (Time.time - lastAttackTime > attackCD)
            {
                lastAttackTime = Time.time;
                Debug.LogError("attack"+Time.time);
                attack();
            }
        }
    }

    public virtual void attack()
    {
        //播放攻击动画
    }

    public virtual void action()
    {
        if(!isInCamera)
            checkInCamera();
        if(!isInCamera)
            return;
        bool inRange = InRange();
        if (inRange)
        {
            isStop = true;
        }
        moveOrAttack();
    }

    public virtual void die()      
    {
        
        Destroy(gameObject);
    }

    
}
