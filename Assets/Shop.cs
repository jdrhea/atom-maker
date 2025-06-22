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

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;


    // purchase buttons
    public void BuyItem1()
    {
        if (Drag.scoreValue >= 50)
        {
            Drag.scoreValue -= 50;
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
        if (Drag.scoreValue >= 200)
        {
            Drag.scoreValue -= 200;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Pressure Cooker", 1);
            }
        }
    }
    public void BuyItem3()
    {
        if (Drag.scoreValue >= 500)
        {
            Drag.scoreValue -= 500;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Atom Splitter", 1);
            }
        }
    }
    public void BuyItem4()
    {
        if (Drag.Temperature >= 10)
        {
            Drag.Temperature -= 10;
            SetScoreTemp();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Ionizer", 1);
            }
        }
    }
    public void BuyItem5()
    {
        if (Drag.Temperature >= 5000)
        {
            Drag.Temperature -= 5000;
            SetScoreTemp();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Fusion Chamber", 1);
            }
        }
    }
    // using of items
    public void UseItem1()
    {
        if (InventoryScript.canUse)
        {
            Instantiate(item1, new Vector3(0, 0, 0), Quaternion.identity);
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.RemoveItem("Proton-Electron Combination", 1);
            }
        }
        else
        {
            Debug.Log("You don't have this item in your inventory");
        }
        
    }
    public void UseItem2()
    {
        if (InventoryScript.canUse2)
        {
            item2.SetActive(true);
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                 playerInventory.RemoveItem("Pressure Cooker", 1);
            }

        }
        else
        {
            Debug.Log("You don't have this item in your inventory");
        }

    }
    public void UseItem3()
    {
    
        if (InventoryScript.canUse3)
        {
            Instantiate(item3, new Vector3(0, 0, 0), Quaternion.identity);
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.RemoveItem("Atom Splitter", 1);
            }
        }
        else
        {
            Debug.Log("You don't have this item in your inventory");
        }
        
        
    }
    public void UseItem4()
    {
    
        if (InventoryScript.canUse4)
        {
            Instantiate(item4, new Vector3(0, 0, 0), Quaternion.identity);
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.RemoveItem("Ionizer", 1);
            }
        }
        else
        {
            Debug.Log("You don't have this item in your inventory");
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
