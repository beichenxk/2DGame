using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.Playables;

public class Directory : MonoBehaviour
{
    Flowchart flowchart;
    public GameObject Trigger;
    public PlayableDirector director;
    void Start()
    {
        flowchart = FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
    }
    public void endDialogue()
    {
        PlayerController.instance.canMove = true;
        Trigger.SetActive(false);
    }
    public void PlayVillager()
    {
        flowchart.ExecuteBlock("进入村子");
        PlayerController.instance.canMove = false;
        PlayerStateManager.instance.stateMachine.ChangeState(PlayerStateManager.instance.idleState);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            director.Play();
            // PlayVillager();

        }
    }

}
