using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerSoundtype{attack1,attack2,move,jump,roll,hang,cure,hurt,dead,invincible,Resurrection,shoot,charge} 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Awake()
    {
        instance=this;
    }
    public AudioSource[] playerSound;
    
    public void playPlayerSound(int index)
    {
        playerSound[index].Stop();
        playerSound[index].Play();
    }
    public void stopPlayerSound(int index)
    {
        playerSound[index].Stop();
    }
}
