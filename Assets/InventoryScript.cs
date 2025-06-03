using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    public List<Items> items = new List<Items>();
    public TextMeshProUGUI inventoryText;

    public void AddItem(string itemName, int quantity = 1)
    {
        Items existingItem = items.Find(item => item.itemName == itemName);
        existingItem.quantity += quantity;
        //Debug.Log($"Added {quantity} {itemName}(s) to inventory.");
        UpdateUI();
    }
    private void UpdateUI()
    {
        string display = "";
        foreach (Items item in items)
        {
            display += "x" + item.quantity + "\n";
        }

        if (inventoryText != null)
            inventoryText.text = display;
    }

}
