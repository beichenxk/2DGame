using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EngineerDetect : MonoBehaviour
{
    private GameObject EngineerPrefab;
    public GameObject EngineerSpawn;
    bool hastrigger=false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!hastrigger)
        {
            
            if (GetComponentInParent<bonfire>().isActive)
            {
                if (other.CompareTag("Player"))
                {
                    EngineerPrefab = Instantiate(bonfireManager.instance.EngineerPrefab, EngineerSpawn.transform.position, quaternion.identity);
                }
                 hastrigger=true;
            }
           
        }


    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(EngineerPrefab);
        }
        hastrigger=false;
    }

}
