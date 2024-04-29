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
    public Transform leftRange;
    public Transform rightRange;

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
        
        if (x > transform.position.x && moveRight)
        {
            float distance = -transform.position.x + x;
            if (distance < Range)
                return true;
        }else if (x < transform.position.x && !moveRight)
        {
            float distance = transform.position.x - x;
            if (distance < Range)
                return true;
        }
            return false;
    }

    public virtual void moveOrAttack()
    {
        var anim = GetComponent<Animator>();
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
            anim.SetBool("attack",false);
            anim.SetBool("move",true);
            
        }
        else
        {
            if (Time.time - lastAttackTime > attackCD)
            {
                lastAttackTime = Time.time;
                attack(anim);
            }
        }
    }

    
    
    
    public virtual void attack(Animator anim)
    {
        anim.SetBool("move",false);
        anim.SetBool("attack",true);
        //播放攻击动画
    }

    public virtual void action()
    {
        if(!isInCamera)
            checkInCamera();
        if(!isInCamera)
            return;
        isStop = InRange();

        moveOrAttack();
    }

    public virtual void HpCheck()      
    {
        if (hp <= 0)
        {
            var anim = GetComponent<Animator>();
            anim.SetBool("dead",true);
        }
    }

    public void BoundCheck()
    {
        
        
        if (transform.position.x - rightRange.position.x>=0)
        {
            moveRight = false;
        }

        if (transform.position.x - leftRange.position.x<=0)
        {
            moveRight = true;
        }
    }

    public  virtual void dead()
    {
        gameObject.SetActive(false);
    }


}
