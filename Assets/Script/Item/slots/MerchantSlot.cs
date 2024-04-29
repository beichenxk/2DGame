using UnityEngine.EventSystems;
using UnityEngine;

public class MerchantSlot : ItemSlot
{
    // public GameObject slot;
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            Debug.Log("购买了" + item.data.itemName);
            merchant.instance.RemoveItem(item.data);
            // Inventory.instance.AddItem(item.data);
        }

    }
}