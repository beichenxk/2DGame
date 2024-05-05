using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatesUI : MonoBehaviour
{
    // public GameObject HpData,MpData,ATKData,SHTData;
    public TextMeshProUGUI HPLevel,MPLevel,ATKLevel,SHTLevel;
    void Awake()
    {

        UpdateData();
    }

    public void UpdateData()
    {
        HPLevel.GetComponent<TextMeshProUGUI>().text=PlayerData.instance._hplevel.ToString();
        MPLevel.GetComponent<TextMeshProUGUI>().text=PlayerData.instance._mplevel.ToString();
        ATKLevel.GetComponent<TextMeshProUGUI>().text=PlayerData.instance._atklevel.ToString();
        SHTLevel.GetComponent<TextMeshProUGUI>().text=PlayerData.instance._shotlevel.ToString();
    }
}
