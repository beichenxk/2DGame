using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public enum DrinkType{red,blue}
public class DrinkChoose : MonoBehaviour
{
    public static DrinkChoose instance;
    Image item;
    public DrinkType currentChoose;

    public Sprite Red,Blue;
    void Awake()
    {
        instance=this;
        item=GetComponent<Image>();
        currentChoose=DrinkType.red;
    }
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            if(currentChoose==DrinkType.red)
            {
                // item.color=Color.blue;
                item.sprite=Blue;
                currentChoose=DrinkType.blue;
            }
            else
            {
                // item.color=Color.red;
                item.sprite=Red;
                currentChoose=DrinkType.red;
            }
        }
    }
}
