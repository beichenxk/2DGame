using UnityEngine.EventSystems;
using UnityEngine;

public class EquipedSlot:ItemSlot
{
    public override void OnPointerDown(PointerEventData eventData)
    {
         if(item.data.itemType==ItemType.equipment)
        {
            Debug.Log("脱下"+item.data.itemName);
            // Inventory.instance.Unequip(item.data);
        }
    }
}