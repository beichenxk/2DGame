using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    [Header("Inventory")]
   public GameObject InventoryUI;
   public bool InventoryIsOpen=false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            
            InventoryUI.SetActive(!InventoryIsOpen);
            InventoryIsOpen=!InventoryIsOpen;
            if(InventoryIsOpen==true)
            {
                Time.timeScale=0;
            }
            else
            {
                Time.timeScale=1;
            }
        }
    }
}
