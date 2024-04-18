using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public class Engineer : MonoBehaviour
{
    public static Engineer instance;
    public bool canSpeak = false;
    public string BlockName;


    void OnValidate()
    {
        instance=this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canSpeak)
            {
                Flowchart flowchart = FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
                if (flowchart.HasBlock(BlockName))
                {
                    flowchart.ExecuteBlock(BlockName);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("玩家进入");
        canSpeak = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("玩家退出");
        canSpeak = false;
    }
    
}
