using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamManager : Singleton<GamManager>
{
    
    public GameObject player;
    public bool isRunning;
    public string saveName;
    public PlayerStateManager playerStateManager;
    //存档加载
    public void LoadGame(string save)
    {
        player=Instantiate(Resources.Load("Player/Player")as GameObject);
        DontDestroyOnLoad(player);
        if (save != string.Empty)
        {
            PlayerData data=DataManager.LoadPlayerData(save);
           
            player.GetComponentInChildren<Player>().PlayerData = data;
            saveName = save;
        }
        else
        {
            saveName = "save1";
        }
        playerStateManager=player.GetComponentInChildren<PlayerStateManager>();
        //playerStateManager.Init();
    }

    
}
