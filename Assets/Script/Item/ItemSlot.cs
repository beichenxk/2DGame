
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerDownHandler
{
    public InventoryItem item;
    public TextMeshProUGUI itemText;

    public virtual void OnPointerDown(PointerEventData eventData) { }

    void OnValidate()
    {
        itemText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public virtual void CleanUpSlot()
    {
        item = null;
        GetComponent<Image>().sprite = null;
        itemText.text = "";
    }
    public virtual void UpdateSlot(InventoryItem item)
    {
        this.item = item;

        GetComponent<Image>().sprite = item.data.icon;
        if (item.stackSize > 0)
        {
            itemText.text = item.stackSize.ToString();
        }
        else
        {
            itemText.text = "";
        }

    }

}
