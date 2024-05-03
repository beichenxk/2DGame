using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class hideroom : MonoBehaviour
{
    public float DisapperSeconds;
    public float DisapperCount;
    Tilemap map;
    bool disappear;
    float alpha;
    
    void Start()
    {
        map = GetComponent<Tilemap>();
    }

    void Update()
    {
        if(disappear)
        {
            DisapperCount+=Time.deltaTime;
            alpha=1-DisapperCount/DisapperSeconds;
            if(alpha>=0)
            {
                map.color=new Vector4(1,1,1,1-DisapperCount/DisapperSeconds);
            }
            else
            {
                gameObject.SetActive(false);
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            disappear=true;
        }
    }
}
