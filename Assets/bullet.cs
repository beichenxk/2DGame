using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float FlySpeed;
    public bool hit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            transform.position += new Vector3(-FlySpeed * Time.deltaTime * transform.localScale.x, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Debug.Log(攻击到敌人);
            hit=true;
            GetComponent<Animator>().CrossFade("hit",0);
        }
    }

    void endHit()
    {
        Destroy(gameObject);
    }
}
