using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryScript : MonoBehaviour
{
    public List<Items> items = new List<Items>();
    public TextMeshProUGUI inventoryText;
    public static bool canUse;
    public static bool canUse2;
    public static bool canUse3;
    public static bool canUse4;

    void Update()
    {
        Debug.Log(canUse);
    }

    public void AddItem(string itemName, int quantity = 1)
    {
        Items existingItem = items.Find(item => item.itemName == itemName);
        existingItem.quantity += quantity;
        if(itemName == "Proton-Electron Combination")
        {
            canUse = true;
        }
        if (itemName == "Pressure Cooker")
        {
            canUse2 = true;
        }
        if (itemName == "Atom Splitter")
        {
            canUse3 = true;
        }
        //Debug.Log($"Added {quantity} {itemName}(s) to inventory.");
        UpdateUI();
    }
    public void RemoveItem(string itemName, int quantity = 1)
    {
        Items existing = items.Find(item => item.itemName == itemName);
        existing.quantity -= quantity;
        // if (existing.quantity >= quantity)
        // {
        //     if (existing.quantity <= 0)
        //     {
        //         canUse = false;
        //     }
        //     else
        //     {
        //         canUse = true;
        //     }
        // }
        // else
        // {
        //     canUse = false;
        // }

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
