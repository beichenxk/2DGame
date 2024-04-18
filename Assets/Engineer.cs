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
        PlayerData.instance._hplevel+=1;
        Debug.Log(PlayerData.instance.maxHp);
    }
    public void addMp()
    {
        PlayerData.instance._mplevel+=1;
    }
    public void addAtk()
    {
        PlayerData.instance._atklevel+=1;
    }
    public void addShot()
    {
        PlayerData.instance._shotlevel+=1;
    }
    
}
