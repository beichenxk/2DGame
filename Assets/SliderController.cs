using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider theSlider;
    public void UpdateSlider(int max,int current)
    {
        theSlider.maxValue=max;
        theSlider.value= current;
    }
}
