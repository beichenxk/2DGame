using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public Vector3 position=new Vector3(0,0,0);//玩家位置
    public int _Basehp = 100;//基础血量
    public int _hplevel = 1;//血量等级
    public int _Basemp = 100;//基础魔法
    public int _mplevel = 1;//魔法等级
    public int _Baseatk = 20;//基础攻击力
    public int _atklevel = 1;//攻击力等级
    public int _Baseshot = 12;//枪械攻击力
    public int _shotlevel = 1;//枪械攻击力等级
    
    public int maxHp
    {
        get { return _Basehp+10*_hplevel; }
    }
    public int maxMp
    {
        get { return _Basemp+10*_mplevel; }
    }
    public int atk
    {
        get { return _Baseatk+_atklevel; }
    }
    public int shot
    {
        get { return _Baseshot+_shotlevel; }
    }

    public int red = 0;//红瓶数量
    public int blue = 0;//蓝瓶数量
    public int exp=0;//经验值
    public int small = 0;//小阿卡纳
    public int large = 0;//大阿卡纳

}

public  class DataManager
{
    public static void SavePlayerData(PlayerData playerData,string fileName)
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