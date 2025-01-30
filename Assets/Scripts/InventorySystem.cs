using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] List<Item> items;

    public WeaponSystem WeaponSystem;

    public List<Item> GetItems()
    {
        return items;
    }

    public void AddItem(Item item)
    {
        if (item is Weapon) 
        {
            WeaponSystem.SetWeapon((Weapon)item);
        }

        for (int i = 0; i < items.Count; i++) 
        {
            if (items[i].name == item.name) 
            {
                items[i].count += item.countStandart;
                FindAnyObjectByType(typeof(InventoryUI)).GetComponent<InventoryUI>().UpdateInventoryUI();
                return;
            }
        }
        item.count = item.countStandart;
        items.Add((Item)item);

        FindAnyObjectByType(typeof(InventoryUI)).GetComponent<InventoryUI>().UpdateInventoryUI();
    }

    public void RemoveItem(Item item) 
    {
        items.Remove(item);
    }

    public bool RemoveBullet() 
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].objectName == "5.45x39")
            {
                items[i].count -= 1;
                if (items[i].count == 0)
                {
                    RemoveItem(items[i]);
                }
                return true;
            }
        }

        return false;
    }
}
