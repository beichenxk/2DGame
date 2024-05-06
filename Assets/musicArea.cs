using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class musicArea : MonoBehaviour
{
    public string musicName;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(musicName=="荒野")
            {
                AudioManager.instance.playMusic((int)Music.huangye);
            }
            if(musicName=="避难所")
            {
                AudioManager.instance.playMusic((int)Music.binansuo);
            }
            if(musicName=="村庄")
            {
                AudioManager.instance.playMusic((int)Music.cunzhuang);
            }
            if(musicName=="村庄室内")
            {
                AudioManager.instance.playMusic((int)Music.cunzhuangshinei);
            }
            if(musicName=="临时舞台")
            {
                AudioManager.instance.playMusic((int)Music.wutai);
            }
        }
    }
}
