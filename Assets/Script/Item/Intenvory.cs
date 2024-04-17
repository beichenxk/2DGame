using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItem> Equiped;
    private InventoryItem EquipedToFind;
    //用list存储不同类型的装备,用于在背包内分开显示
    public List<InventoryItem> Equipment;
    private InventoryItem EquipmentToFind;

    void Awake()
    {
        instance = this;
        Equipment = new List<InventoryItem>();
    }

    public void AddItem(ItemData data)
    {
        EquipmentToFind = null;
        if (data.itemType == ItemType.equipment)
        {
            EquipmentToFind = Equipment.Find(obj => obj.data.itemName == data.itemName);
            if (EquipmentToFind != null)
            {
                EquipmentToFind.AddStack();
            }
            else
            {
                InventoryItem newEquipment = new InventoryItem(data);
                Equipment.Add(newEquipment);
            }
        }
        InventoryUI.instance.UpdateSlot();
    }

    public void RemoveItem(ItemData data)
    {
        EquipmentToFind = null;
        if (data.itemType == ItemType.equipment)
        {
            EquipmentToFind = Equipment.Find(obj => obj.data.itemName == data.itemName);
            if (EquipmentToFind.stackSize <= 1)
            {
                Equipment.Remove(EquipmentToFind);
            }
            else
            {
                EquipmentToFind.RemoveStack();
            }
        }

        InventoryUI.instance.UpdateSlot();
    }

    public void Equip(ItemData data)
    {
        RemoveItem(data);
        InventoryItem newItem=new InventoryItem(data);
        Equiped.Add(newItem);
        InventoryUI.instance.UpdateSlot();
    }

    public void Unequip(ItemData data)
    {
        AddItem(data);
        EquipedToFind=Equiped.Find(obj=>obj.data.itemName==data.itemName);
        Equiped.Remove(EquipedToFind);
        InventoryUI.instance.UpdateSlot();
    }
}
