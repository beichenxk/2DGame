using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    // private SpriteRenderer theSR;
    // public ItemData data;
    public GameObject item;
    // Start is called before the first frame update

    void Start()
    {
        item.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
            // Debug.Log(data.name+" is picked up!");
            // Inventory.instance.AddItem(data);
            // Destroy(gameObject);
            if(other.CompareTag("Player"))
            {
                item.SetActive(true);
                Destroy(gameObject);
            }
    }
}
