using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject item; // Reference to the item GameObject
    public Text score;
    public TMP_Text TemperatureTxt;
    public void BuyItem1()
    {
        if (Drag.scoreValue >= 30)
        {
            Drag.scoreValue -= 30;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Proton-Electron Combination", 1);
            }
        }
    }
    public void BuyItem2()
    {
        if (Drag.scoreValue >= 50)
        {
            Drag.scoreValue -= 50;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Pressure Chamber", 1);
            }
        }
    }
    public void BuyItem3()
    {
        if (Drag.scoreValue >= 100)
        {
            Drag.scoreValue -= 100;
            SetScore();
            // Inventory playerInventory = item.GetComponent<Inventory>();
            // if (playerInventory != null)
            // {
            //     playerInventory.AddItem("Atom Splitter", 1);
            // }
        }
    }
    public void BuyItem4()
    {
        if (Drag.Temperature >= 500)
        {
            Drag.Temperature -= 500;
            SetScoreTemp();
            // Inventory playerInventory = item.GetComponent<Inventory>();
            // if (playerInventory != null)
            // {
            //     playerInventory.AddItem("Ionizer", 1);
            // }
        }
    }
    public void BuyItem5()
    {
        if (Drag.Temperature >= 5000)
        {
            Drag.Temperature -= 5000;
            SetScoreTemp();
            // Inventory playerInventory = item.GetComponent<Inventory>();
            // if (playerInventory != null)
            // {
            //     playerInventory.AddItem("Fusion Chamber", 1);
            // }
        }
    }
    void SetScore()
    {
        score.text = "Money: $" + Drag.scoreValue;

    }
    void SetScoreTemp()
    {
        TemperatureTxt.text = "Temperature: " + Drag.Temperature + "kK";
    }

}
