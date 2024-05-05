using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReadingMaterial : MonoBehaviour, IPointerClickHandler
{
    public GameObject detail;
    [TextArea]
    public string ReadingText;
    public void OnPointerClick(PointerEventData eventData)
    {
        detail.SetActive(true);
        detail.transform.Find("Description").GetComponent<Text>().text = ReadingText;
    }


}
