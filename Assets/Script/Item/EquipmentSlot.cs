using UnityEngine.EventSystems;
using UnityEngine;

public class EquipmentSlot:ItemSlot
{
    // public GameObject slot;
    public override void OnPointerDown(PointerEventData eventData)
    {
         if(item.data.itemType==ItemType.equipment)
        {
            // string imageName = gameObject.name;
            // Debug.Log("Clicked image name: " + imageName);
            Debug.Log("穿上"+item.data.itemName);
            Inventory.instance.Equip(item.data);
        }
    }
}