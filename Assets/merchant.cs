using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting;
using UnityEngine;

public class merchant : MonoBehaviour
{
    public static merchant instance;
    public bool canSpeak = false;
    public string BlockName;

    public GameObject tradeUI;
    public List<InventoryItem> Items;
    private InventoryItem ItemToFind;

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
        TradeUI.instance.UpdateSlot();
        canSpeak = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("玩家退出");
        canSpeak = false;
    }

    public void startTrade()
    {
        // Debug.Log("这里应该进行交易");
        tradeUI.SetActive(true);
    }
    public void stopTrade()
    {
        tradeUI.SetActive(false);
    }

    public void RemoveItem(ItemData data)
    {
        ItemToFind = null;
        ItemToFind = Items.Find(obj => obj.data.itemName == data.itemName);
        if (ItemToFind.stackSize <= 1)
        {
            Items.Remove(ItemToFind);
        }
        else
        {
            ItemToFind.RemoveStack();
        }


        TradeUI.instance.UpdateSlot();
    }

    
}
