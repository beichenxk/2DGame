using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int health;
    public int score;
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