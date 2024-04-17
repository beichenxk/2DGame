using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    public GameObject EquipedParent;
    public EquipedSlot[] Equipedslots;
    public GameObject EquipmentParent;
    public EquipmentSlot[] Equipmentslots;

    void OnValidate()
    {
        instance =this;
        Equipedslots = EquipedParent.GetComponentsInChildren<EquipedSlot>();
        Equipmentslots = EquipmentParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public void UpdateSlot()
    {
        #region 清除部分
        {
            for (int i = 0; i < Equipmentslots.Length; ++i)
            {
                Equipmentslots[i].CleanUpSlot();
            }

            for (int i = 0; i < Equipedslots.Length; ++i)
            {
                Equipedslots[i].CleanUpSlot();
            }
        }
        #endregion

        #region 添加部分
        {
            for (int i = 0; i < Inventory.instance.Equipment.Count; ++i)
            {
                Equipmentslots[i].UpdateSlot(Inventory.instance.Equipment[i]);
            }

            for (int i = 0; i < Inventory.instance.Equiped.Count; ++i)
            {
                Equipedslots[i].UpdateSlot(Inventory.instance.Equiped[i]);
            }
        }
        #endregion



    }
}