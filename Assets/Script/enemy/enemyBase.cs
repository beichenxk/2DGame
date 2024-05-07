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
    public bool isStop = false; //敌人是否停止移动
    public bool isInCamera = false; //是否在摄像机视野中
    public Transform leftRange;
    public Transform rightRange;

    public float knockbackForce;//判断击退的力度
    public float stunTime;//碰到怪物击退后晕眩时间

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
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = new Vector2(1, 0);
        if (!moveRight)
            direction = new Vector2(-1, 0);

        int layerMask = LayerMask.GetMask("player");
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Range,layerMask);
        if (hit.collider != null)
        {
            Debug.LogError("hit :"+hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Player"))
                return true;
            return false;
        }

        /*float x = player.transform.position.x;

        if (x > transform.position.x && moveRight)
        {
            float distance = -transform.position.x + x;
            if (distance < Range)
                return true;
        }
        else if (x < transform.position.x && !moveRight)
        {
            float distance = transform.position.x - x;
            if (distance < Range)
                return true;
        }
        return false;*/
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
            anim.SetBool("attack", false);
            anim.SetBool("move", true);

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
        anim.SetBool("move", false);
        anim.SetBool("attack", true);
        //播放攻击动画
    }

    public virtual void action()
    {
        if (!isInCamera)
            checkInCamera();
        if (!isInCamera)
            return;
        isStop = InRange();

        moveOrAttack();
    }

    public virtual void HpCheck()
    {
        if (hp <= 0)
        {
            var anim = GetComponent<Animator>();
            anim.SetBool("dead", true);
        }
    }

    public void BoundCheck()
    {


        if (transform.position.x - rightRange.position.x >= 0)
        {
            moveRight = false;
        }

        if (transform.position.x - leftRange.position.x <= 0)
        {
            moveRight = true;
        }
    }

    public virtual void dead()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("进入碰撞");
        if (other.CompareTag("Player")&&!PlayerData.instance.isInvincible)
        {
            StartCoroutine(StunCo());// 碰到怪物后晕眩一段时间,玩家无法操作
        }
        if (other.gameObject.tag == "attack")
        {
            Debug.LogError("碰到攻击物体");
            hp -= PlayerData.instance.atk;
            StartCoroutine(BeAttack());
        }
    }

    IEnumerator StunCo()
    {
        // AudioManager.instance.playPlayerSound((int)playerSoundtype.invincible);
        PlayerController.instance.canMove = false;
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        PlayerController.instance.rb.velocity = new Vector2(PlayerController.instance.transform.localScale.x * knockbackForce, PlayerController.instance.rb.velocity.y);
        yield return new WaitForSeconds(stunTime);
        PlayerController.instance.rb.velocity = new Vector2(0, PlayerController.instance.rb.velocity.y);
        PlayerController.instance.canMove = true;
    }

    IEnumerator BeAttack()
    {
        var material = GetComponent<SpriteRenderer>().material;
        for (int i = 0; i <= 10d; i++)
        {
            material.color=Color.red;
            yield return null;
        }
        material.color = Color.white;
    }


    public GameObject _zidan;

    public int zidanTime = 10;

    public float zidanSpeed = 1;
    //远程攻击
    public void farAttack()
    {
        if (_zidan != null)
        {
            StartCoroutine(zidanMove());
        }
    }

    IEnumerator zidanMove()
    {
        
        GameObject zidan = Instantiate(_zidan);
        zidan.transform.position = transform.position;
        for (int i = 0; i < zidanTime; i++)
        {
            if (moveRight)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            yield return null;
        }
    }


}
