using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatesUI : MonoBehaviour
{
    // public GameObject HpData,MpData,ATKData,SHTData;
    public Text HPLevel,MPLevel,ATKLevel,SHTLevel;
    void Awake()
    {

        UpdateData();
    }

    public void UpdateData()
    {
        HPLevel.GetComponent<Text>().text=PlayerData.instance._hplevel.ToString();
        MPLevel.GetComponent<Text>().text=PlayerData.instance._mplevel.ToString();
        ATKLevel.GetComponent<Text>().text=PlayerData.instance._atklevel.ToString();
        SHTLevel.GetComponent<Text>().text=PlayerData.instance._shotlevel.ToString();
    }
}
