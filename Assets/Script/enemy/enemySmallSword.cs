using System.Collections;
using System.Collections.Generic;
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
        spriteRenderer.flipX=moveRight;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.CompareTag("bound"))
        {
            moveRight=!moveRight;
        }

        Debug.LogError("moveRight:" + moveRight);
    }
}
