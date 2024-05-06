using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   public static LevelManager instance;
    public float respawnTime;
    [Header("隐藏的对象")]
    public GameObject bonfire;
    public GameObject wall;
    public GameObject core;
    void Awake()
    {
        instance=this;
    }
    public void respawn()
    {
        StartCoroutine(respawnCo());
    }
    private IEnumerator respawnCo()
    {
        yield return new WaitForSeconds(respawnTime);
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
        PlayerData.instance.Refresh();
        PlayerController.instance.transform.position=bonfireManager.instance.spawnPoint;
        PlayerController.instance.ChangeAnimation("Resurrection");
        FindObjectOfType<Flowchart>().GetComponent<Flowchart>().SetBooleanVariable("DieBefore",true);       //用于判定对话选择
        cameraController.instance.freeCamera();
        // PlayerData.instance.ChangeHealth(PlayerData.instance.maxHp);
        // PlayerData.instance.ChangeMana(PlayerData.instance.maxMp);
        PlayerData.instance.Refresh();
    }

    public void DefeatBoss()
    {
        bonfire.SetActive(true);
        wall.SetActive(false);
        core.SetActive(true);
    }
}
