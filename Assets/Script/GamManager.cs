using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamManager : Singleton<GamManager>
{
    
    public GameObject player;

    //存档加载
    public void LoadGame(string saveName)
    {
        if (saveName != string.Empty)
        {
            PlayerData data=DataManager.LoadPlayerData(saveName);
        }
    }

    
}
