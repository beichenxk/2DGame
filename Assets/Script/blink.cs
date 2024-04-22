using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class blink : MonoBehaviour
{
    
    [ContextMenu("bink effect")]
    void blinkEffect()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink() 
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();

        for (int i = 0; i < 120; i++)
        {
            float alpha = 1;
            if (i % 4 == 0)
            {
                alpha = 0.25f;
            }else if (i % 4 == 1)
            {
                alpha = 0.5f;
            }else if (i % 4 == 2)
            {
                alpha= 0.75f;
            }
            else
            {
                alpha = 1;
            }

            Color color = new Color(1, 1, 1, alpha);
            renderer.color = color;
            yield return null;
        }
        renderer.color = new Color(1, 1, 1, 1);
    }
}
