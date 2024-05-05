// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TradeUI : MonoBehaviour
// {
//     public static TradeUI instance;
//     public GameObject itemsParent;
//     public MerchantSlot[] merchantSlots;

//     void OnValidate()
//     {
//         instance =this;
//         merchantSlots = itemsParent.GetComponentsInChildren<MerchantSlot>();
//     }
//     public void UpdateSlot()
//     {
//         #region 清除部分
//         {
//             for (int i = 0; i < merchantSlots.Length; ++i)
//             {
//                 merchantSlots[i].CleanUpSlot();
//             }
//         }
//         #endregion

//         #region 添加部分
//         {
//             for (int i = 0; i < merchant.instance.Items.Count; ++i)
//             {
//                 merchantSlots[i].UpdateSlot(merchant.instance.Items[i]);
//             }
//         }
//         #endregion



//     }
// }
