using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class platform : MonoBehaviour
{
    public bool OntheSurface;
    void Update()
    {
        if (OntheSurface)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                GetComponent<PlatformEffector2D>().surfaceArc = 0;
            }
        }

    }
    void OnCollisionExit2D()
    {
        GetComponent<PlatformEffector2D>().surfaceArc = 145;
        OntheSurface=false;
    }
    void OnCollisionEnter2D()
    {
        OntheSurface = true;
    }
}
