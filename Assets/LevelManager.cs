using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class LevelManager : MonoBehaviour
{   public static LevelManager instance;
    public float respawnTime;
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
        FindObjectOfType<Flowchart>().GetComponent<Flowchart>().SetBooleanVariable("DieBefore",true);       //用于判定对话选择

    }
}
