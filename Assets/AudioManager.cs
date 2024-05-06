using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum playerSoundtype{attack1,attack2,move,jump,roll,hang,cure,hurt,dead,invincible,Resurrection,shoot,charge}
enum Music{huangye,binansuo,cunzhuang,cunzhuangshinei,wutai} 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    void Awake()
    {
        instance=this;
    }
    public AudioSource[] playerSound;
    public AudioSource[] Music;
    
    public void playPlayerSound(int index)
    {
        playerSound[index].Stop();
        playerSound[index].Play();
    }
    public void stopPlayerSound(int index)
    {
        playerSound[index].Stop();
    }
    public void playMusic(int index)
    {
        stopAllMusic();
        Music[index].Play();
    }
    public void stopAllMusic()
    {
        for(int i=0;i<Music.Length;i++)
        {
            Music[i].Stop();
        }
    }
}
