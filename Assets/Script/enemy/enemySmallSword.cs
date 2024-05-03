using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemySmalldSword : enemyBase
{
    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyName = "机械小兵（剑）";
        exp = 100;
        hp = 70;
        isStop=false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        action();
        
        if (moveRight)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        BoundCheck();
        HpCheck();
    }

    //将小兵的ontriggerenter写入基类中

    public override void dead()
    {
        base.dead();
    }
    
}
