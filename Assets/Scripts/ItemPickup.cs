using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventorySystem playerInventory = FindObjectOfType<InventorySystem>();
            playerInventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
