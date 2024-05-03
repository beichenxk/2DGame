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

    public GameObject UpdateUI;

    public Flowchart flowchart;
    private Animator theAni;



    void OnValidate()
    {
        instance = this;
        
    }
    void Start()
    {
        flowchart = FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
        theAni = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canSpeak)
            {
                
                if (flowchart.HasBlock(BlockName))
                {
                    flowchart.ExecuteBlock(BlockName);
                    theAni.CrossFade("Chat",0);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug.Log("玩家进入");
        canSpeak = true;
        Utility.instance.canAttack = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Debug.Log("玩家退出");
        canSpeak = false;
        if(flowchart.GetExecutingBlocks().Count!=0)
        {
            flowchart.StopAllBlocks();
           
        }

         StopChat();
            
        
        Utility.instance.canAttack = true;
    }
    public void StopChat()
    {
        theAni.CrossFade("Idle",0);
    }
    public void openUpdateUI()
    {
        UpdateUI.SetActive(true);
    }
    public void closeUpdateUI()
    {
        UpdateUI.SetActive(false);
    }

    public void addHp()
    {
        PlayerData.instance._hplevel += 1;
        Debug.Log(PlayerData.instance.maxHp);
    }
    public void addMp()
    {
        PlayerData.instance._mplevel += 1;
    }
    public void addAtk()
    {
        PlayerData.instance._atklevel += 1;
    }
    public void addShot()
    {
        PlayerData.instance._shotlevel += 1;
    }

}
