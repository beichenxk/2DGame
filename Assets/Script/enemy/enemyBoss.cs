using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class enemyBoss : MonoBehaviour
{

    public float knockbackForce;//判断击退的力度
    public float stunTime;//碰到怪物击退后晕眩时间
    [Serializable]
    public class Skill
    {
        [Header("技能CD")]
        public float cd = 1;

        [Header("技能伤害")]
        public int hurt = 10;

        [Header("技能索敌距离")]
        public float range = 1.5f;

        //上一次攻击时间
        public float lastAttackTime = 0;

        public string skillName;
    }



    [Header("一阶段动作")]
    public AnimatorController Animator1;
    [Header("二阶段动作")]
    public AnimatorController Animator2;

    [Header("boss血量")]
    public int hp = 400;

    private bool isInSecond = false;

    private bool isDead = false;

    public float speed = 2;

    public List<Skill> Skills = new List<Skill>();

    //一阶段

    [Header("平A")]
    public Skill attack;
    [Header("冲击波")]
    public Skill shockWave;
    [Header("砸地")]
    public Skill crash;


    //二阶段
    [Header("二阶段_平A")]
    public Skill attack2;
    [Header("二阶段_冲击波")]
    public Skill shockWave2;

    [Header("二阶段_砸地1")]
    public Skill crash1;
    [Header("二阶段_砸地2")]
    public Skill crash2;


    public Animator animator;

    public bool isUseSKill = false;
    private void Start()
    {
        attack.lastAttackTime = Time.time + attack.cd;
        shockWave.lastAttackTime = Time.time + shockWave.cd;
        crash.lastAttackTime = Time.time + crash.cd;
        Skills.Add(attack);
        Skills.Add(shockWave);
        Skills.Add(crash);
        animator = transform.GetComponent<Animator>();
    }

    public Skill currentSKill = null;
    public Queue<Skill> canUseSkill = new Queue<Skill>();

    public bool isinit = false;
    // Update is called once per frame
    void Update()
    {
        //获取Animator状态是否空闲
        if (animator == null)
            animator = GetComponent<Animator>();

        checkInCD();
        if (canUseSkill.Count > 0 && !isUseSKill)
        {
            currentSKill = canUseSkill.Dequeue();
            isUseSKill = true;
        }

        if (isUseSKill)
        {
            if (checkInRange())
            {
                bool isWalk = animator.GetBool("walk");
                if (isWalk)
                {
                    bool isInSkill = animator.GetBool(currentSKill.skillName);
                    if (!isInSkill)
                    {
                        //释放技能
                        animator.SetBool("walk", false);
                        animator.SetBool(currentSKill.skillName, true);
                        if (currentSKill.skillName == "shockwave")
                            Debug.Log("wave");
                        currentSKill.lastAttackTime = Time.time;

                    }
                }
            }
            else
            {
                if (!isDead)
                {
                    GameObject player = GameObject.Find("Sprite");
                    if (player.transform.position.x > transform.position.x)
                    {
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                        transform.localScale = new Vector3(-1, 1, 1);
                    }
                    else
                    {
                        transform.Translate(Vector3.left * speed * Time.deltaTime);
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                    animator.SetBool("walk", false);
                    animator.SetBool("move", true);
                }

            }
        }


        var animstate = animator.GetCurrentAnimatorStateInfo(0);
        if (animstate.normalizedTime > 1f && !animstate.IsName("Idle"))
        {
            setWalk();
            isUseSKill = false;
        }
        checkHp();


    }

    bool checkInRange()
    {
        GameObject player = GameObject.Find("Sprite");
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < currentSKill.range)
            return true;
        return false;
    }

    void checkInCD()
    {
        for (int i = 0; i < Skills.Count; i++)
        {
            var sk = Skills[i];
            if ((Time.time - sk.lastAttackTime) > sk.cd)
            {
                if (!canUseSkill.Contains(sk))
                    canUseSkill.Enqueue(sk);
            }
        }
    }



    void checkHp()
    {
        if (hp <= 200 && !isInSecond)
        {
            isInSecond = true;
            animator.SetBool("trans", true);
        }

        if (hp <= 0)
        {
            isDead = true;
            animator.SetBool("dead", true);
        }
    }

    void UpdateSKill()
    {
        animator.runtimeAnimatorController = Animator2;
        Skills.Clear();
        attack2.lastAttackTime = Time.time + attack2.cd;
        shockWave2.lastAttackTime = Time.time + shockWave2.cd;
        crash1.lastAttackTime = Time.time + crash1.cd;
        crash2.lastAttackTime = Time.time + crash2.cd;
        Skills.Add(attack2);
        Skills.Add(shockWave2);
        Skills.Add(crash1);
        Skills.Add(crash2);
    }

    public virtual void dead()
    {
        // gameObject.SetActive(false);
        FindObjectOfType<Flowchart>().GetComponent<Flowchart>().ExecuteBlock("击败机械裁决官");
        animator.enabled = false;
        LevelManager.instance.DefeatBoss();
    }

    void setWalk()
    {

        animator.SetBool("trans", false);
        animator.SetBool("move", false);
        animator.SetBool("attack", false);
        animator.SetBool("crash", false);
        animator.SetBool("crash1", false);
        animator.SetBool("crash2", false);
        animator.SetBool("shockwave", false);
        animator.SetBool("walk", true);
    }


    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("进入碰撞");
        if (other.CompareTag("Player") && !PlayerData.instance.isInvincible)
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
            material.color = Color.red;
            yield return null;
        }
        material.color = Color.white;
    }
}
