using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[System.Serializable]
public class Items
{
    public string itemName;
    public int quantity;

    public Items(string name, int qty = 1)
    {
        itemName = name;
        quantity = qty;
    }
}
