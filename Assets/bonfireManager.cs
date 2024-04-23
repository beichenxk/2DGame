using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UIElements;

public class bonfireManager : MonoBehaviour
{
    public static bonfireManager instance;
    public List<bonfire> unlockedbonfires = new List<bonfire>(); // 存储已解锁的篝火
    public Vector3 spawnPoint;
    Flowchart flowchart;

    public GameObject EngineerPrefab;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        spawnPoint = new Vector3((float)-1.9, (float)-1.38, (float)0.03);//第一个篝火的位置
        flowchart = FindObjectOfType<Flowchart>().GetComponent<Flowchart>();
    }

    public void UnlockBonfire(bonfire newbonfire)
    {
        unlockedbonfires.Add(newbonfire);
    }
    public void transmit()
    {
        string transChoose = flowchart.GetStringVariable("transChoose");
        bonfire destination = unlockedbonfires.Find(obj => obj.Name == transChoose);
        PlayerController.instance.transform.position = destination.transform.position;
    }
}
