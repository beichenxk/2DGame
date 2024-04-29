using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentCards : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerClickHandler
{
    private RectTransform RT;
    private Image OriginalImg;

    public Transform originalParent;

    public bool Moveback;
    public float MoveSpeed;
    public Transform UI;
    public Vector3 StartPoint;
    public string Cardname;
    public Sprite fullCard;
    public Sprite miniCard;

    public GameObject detail;

    public bool canRevert;
    [TextArea]
    public string CardText;
    
    

    void OnValidate()
    {
        RT = GetComponent<RectTransform>();
        OriginalImg = GetComponent<Image>();

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector3(0.8f, 7.5f, 1);
        OriginalImg.sprite = fullCard;
        transform.SetParent(UI.transform);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(RT, eventData.position, eventData.pressEventCamera, out Vector3 MousePosition))
        {
            RT.position = MousePosition;
        }
        // Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Slot1_equiped"||
        eventData.pointerCurrentRaycast.gameObject.name == "Slot2_equiped"||
        eventData.pointerCurrentRaycast.gameObject.name == "Slot3_equiped")
        {
            transform.localScale = new Vector3(0.2f, 1.4f, 1);
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
            transform.localPosition=Vector3.zero;
            // Debug.Log(123);
            EquipCard();
        }
        else
        {
            transform.SetParent(originalParent);
            transform.SetAsFirstSibling();
            transform.localScale = new Vector3(1, 1, 1);
            Moveback = true;
            OriginalImg.sprite = miniCard;
            
            UnequipCard();
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        detail.SetActive(true);
        detail.transform.Find("Description").GetComponent<Text>().text=CardText;
        detail.transform.Find("Image").GetComponent<Image>().sprite=fullCard;
        if(canRevert)
        {
            detail.transform.Find("Revert").gameObject.SetActive(true);
        }
        else
        {
            detail.transform.Find("Revert").gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Moveback)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, StartPoint, MoveSpeed * Time.deltaTime * 100f);
            if (transform.localPosition == StartPoint)
            {
                Moveback = false;
            }
        }
    }

    public void EquipCard()
    {
        if(Cardname=="fool")
        {
            PlayerData.instance.Hpmodifier=0.15f;
            Debug.Log(PlayerData.instance.maxHp);
        }
    }

    public void UnequipCard()
    {
        if(Cardname=="fool")
        {
            PlayerData.instance.Hpmodifier=0;
            Debug.Log(PlayerData.instance.maxHp);

        }
    }

    
}
