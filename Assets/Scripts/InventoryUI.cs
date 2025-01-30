using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    public InventorySystem playerInventory;

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        foreach (Transform child in inventoryPanel.transform)
        {
            Destroy(child.gameObject);
        }

        int index = 0;
        foreach (Item item in playerInventory.GetItems())
        {
            GameObject newSlot = Instantiate(slotPrefab, inventoryPanel.transform);
            Slot slot = newSlot.GetComponent<Slot>();
            slot.SetupSlot(item);

            Button slotButton = slot.slotButton;
            slotButton.onClick.AddListener(() => slot.OnSlotClicked());

            RectTransform rect = newSlot.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2((index % 2) * 100, -(index / 2) * 100);

            index++;
        }
    }

    public void RemoveItem(Item item)
    {
        playerInventory.RemoveItem(item);
        UpdateInventoryUI();
    }
}
