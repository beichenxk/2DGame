using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testControl : MonoBehaviour
{
    
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public float input = 0f;
    // Update is called once per frame
    void Update()
    { 
        input = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(input * 5, rb.velocity.y);
    }
}
