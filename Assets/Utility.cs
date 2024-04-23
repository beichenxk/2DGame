using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Utility instance;
    [Header("Inventory")]
    public GameObject InventoryUI;
    public bool InventoryIsOpen = false;
    public GameObject MinimapUI;
    public bool MinimapIsOpen = false;
    [Header("Property")]
    public bool canAttack=true;

    void Awake()
    {
        instance=this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            InventoryUI.SetActive(!InventoryIsOpen);
            InventoryIsOpen = !InventoryIsOpen;
            if (InventoryIsOpen == true)
            {
                Time.timeScale = 0;
                canAttack=false;
            }
            else
            {
                Time.timeScale = 1;
                canAttack=true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            MinimapUI.SetActive(!MinimapIsOpen);
            MinimapIsOpen = !MinimapIsOpen;
        }
    }
}
