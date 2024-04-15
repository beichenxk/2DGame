using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData PlayerData;
    
    // Start is called before the first frame update
    void Start()
    {
        GamManager.Instance.isRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
