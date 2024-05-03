using System;
using Unity.Mathematics;
using UnityEngine;
public class PlayerShootState : State
{
    public float keydownTime;//记录按键时间
    
    public PlayerShootState(StateMachine stateMachine, string aniBoolName) : base(stateMachine, aniBoolName)
    {
    }

    public override void Enter()
    {
        // Debug.Log("enter shoot");
        PlayerController.instance.ChangeAnimation("Shoot");
        keydownTime=Time.time;
    }
    public override void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time-keydownTime<=0.3)
            {
                PlayerController.instance.charge=false;
            }
            else
            {
                PlayerController.instance.charge=true;
                if(!AudioManager.instance.playerSound[(int)playerSoundtype.charge].isPlaying)
                {
                    AudioManager.instance.playerSound[(int)playerSoundtype.charge].Play();
                }
            }
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(!PlayerController.instance.charge)
            {
                PlayerController.instance.shoot();
            }
            else
            {
                AudioManager.instance.playerSound[(int)playerSoundtype.charge].Stop();
                PlayerController.instance.shoot(true);
                PlayerController.instance.charge=false;
            }
        }
    }

    public override void FixedUpdate()
    {
    }
    public override void Exit()
    {
        // Debug.Log("end shoot");
        
    }


}