using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Fungus;
using UnityEditor.ShaderGraph;
using UnityEngine;
[System.Serializable]
public class PlayerData:MonoBehaviour
{
    // public Vector3 position=new Vector3(0,0,0);//玩家位置
    public static PlayerData instance;
    void OnValidate()
    {
        instance = this;
        
    }
    void Awake()
    {
        currentHP=maxHp;
        currentMP=maxMp;
    }
    [Header("Level")]
    public int _hplevel = 1;//血量等级
    public int _mplevel = 1;//魔法等级
    public int _atklevel = 1;//攻击力等级
    public int _shotlevel = 1;//枪械攻击力等级
    [Header("BaseSetting")]
    public int _Baseatk = 20;//基础攻击力
    public int _Basehp = 100;//基础血量
    public int _Basemp = 100;//基础魔法
    public int _Baseshot = 12;//枪械攻击力
    
    [Header("Property")]    //因为后面加上buff后未必是整数,我觉得应该改成一个float类型的数据,血量和蓝量数据也应该存在存档里
    public int currentHP;
    public int currentMP;
    public int red = 2;//红瓶数量
    public int blue = 1;//蓝瓶数量
    [Header("OtherStatics")]
    public int exp = 0;//经验值
    public int small = 0;//小阿卡纳
    public int large = 0;//大阿卡纳
    [Header("HUD")]//用于控制血量和蓝量的显示
    public SliderController HealthSlider;
    public SliderController ManaSlider;
 

    public int maxHp
    {
        get { return _Basehp + 10 * _hplevel; }
    }
    public int maxMp
    {
        get { return _Basemp + 10 * _mplevel; }
    }
    public int atk
    {
        get { return _Baseatk + _atklevel; }
    }
    public int shot
    {
        get { return _Baseshot + _shotlevel; }
    }

    
    public void ChangeHealth(int num)
    {
        currentHP=Math.Clamp(currentHP+num,0,maxHp);
        // HealthSlider.UpdateSlider(maxHp,currentHP);
        if(currentHP<=0)
        {
            // Debug.Log("执行死亡");
            PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.deadState);
        }
    }
    public void ChangeMana(int num)
    {
        currentMP=Math.Clamp(currentMP+num,0,maxMp);
        // ManaSlider.UpdateSlider(maxMp,currentMP);
    }

    public void Refresh()
    {
        currentHP=maxHp;
        currentMP=maxMp;
    }

 


   

}

public class DataManager
{
    public static void SavePlayerData(PlayerData playerData, string fileName)
    {
        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/" + fileName, jsonData);
    }

    public static PlayerData LoadPlayerData(string fileName)
    {
        if (File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/" + fileName);
            return JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            Debug.Log("File not found");
            return null;
        }
    }

    
}