using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;
    public Button slotButton;
    public Button deleteButton;
    public TextMeshProUGUI count;

    private void Start()
    {
        deleteButton.onClick.AddListener(OnDeleteButtonClick);
        deleteButton.gameObject.SetActive(false);
    }

    public void SetupSlot(Item newItem)
    {
        item = newItem;
        slotButton.GetComponentInChildren<Image>().sprite = item.itemSprite;
        count.text = item.count == 1 ? "" : item.count.ToString();
        deleteButton.gameObject.SetActive(false);
    }

    public void OnSlotClicked()
    {
        deleteButton.gameObject.SetActive(!deleteButton.gameObject.active);
    }

    private void OnDeleteButtonClick()
    {
        InventoryUI inventory = FindObjectOfType<InventoryUI>();
        inventory.RemoveItem(item);
        deleteButton.gameObject.SetActive(false);
    }
}
