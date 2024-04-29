using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInfo : MonoBehaviour,IPointerClickHandler
{   
    private Transform Image;
    void OnValidate()
    {
        Image=transform.Find("Image").transform;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        transform.gameObject.SetActive(false);
        resetImage();
    }

    public void RevertCard()
    {
        
        Image.localScale=new Vector3(1,-Image.localScale.y,1);
    }

    public void resetImage()
    {
        transform.Find("Image").transform.localScale=new Vector3(1,1,1);
    }

}
