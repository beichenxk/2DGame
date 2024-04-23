using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Fungus;
using System;
using Unity.Mathematics;

public class bonfire : MonoBehaviour
{
    public string Name;
    public string BlockName;
    bool inCampFire;
    // public GameObject HintButton;
    Flowchart flowchart;
    
    void Start()
    {
        // HintButton.SetActive(false);
        flowchart = FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
    }
    void Update()
    {
        if (inCampFire)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerData.instance.red=2;
                PlayerData.instance.blue=1;

                if (!bonfireManager.instance.unlockedbonfires.Find(obj => obj.Name == this.Name))
                {
                    Debug.Log("已点燃篝火" + this.Name);
                    bonfireManager.instance.UnlockBonfire(this);
                    bonfireManager.instance.spawnPoint = transform.position;
                    setFungusBoolVariable(this.Name);
                    GetComponent<SpriteRenderer>().color = Color.red;
                    PlayerData.instance.red=2;
                    PlayerData.instance.blue=1;
                }
                else
                {
                    // Debug.Log("你已经点燃篝火了");

                    if (flowchart.HasBlock(BlockName))
                    {
                        flowchart.ExecuteBlock(BlockName);
                    }
                }

                // foreach (bonfire camp in bonfireManager.instance.unlockedcampfires)
                // {
                //     if (camp.Name == this.Name)
                //     {
                //         Debug.Log("这个是营火" + this.Name);
                //     }
                // }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            inCampFire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inCampFire = false;
            if (flowchart.HasBlock(BlockName))
            {
                flowchart.StopAllBlocks();
            }
        }
    }

    private void setFungusBoolVariable(String name)
    {
        if (name == "1")
            flowchart.SetBooleanVariable("trans1", true);
        else if (name == "2")
            flowchart.SetBooleanVariable("trans2", true);
    }

}
