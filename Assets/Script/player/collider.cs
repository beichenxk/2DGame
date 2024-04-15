using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    //不可穿越类型，地板，围墙设置bound层
    
    //无敌，以及地形穿越，设置玩家碰撞层级
    void SetLayer()
    {
        gameObject.layer = LayerMask.NameToLayer("IgnoreCollier");
    }
    
    
    //交互 篝火存档
    
}
