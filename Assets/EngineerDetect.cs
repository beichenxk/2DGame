using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EngineerDetect : MonoBehaviour
{
    private GameObject EngineerPrefab;
    public GameObject EngineerSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            EngineerPrefab = Instantiate(bonfireManager.instance.EngineerPrefab, EngineerSpawn.transform.position, quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(EngineerPrefab);
        }
    }

}
