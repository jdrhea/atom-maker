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
    public GameObject item5;
    public Image CantAfford;


    // purchase buttons
     private IEnumerator HideCantAfford()
    {
        yield return new WaitForSeconds(2f);
        CantAfford.gameObject.SetActive(false);
    }

    // purchase buttons
    public void BuyItem1()
    {
        if (Atoms.scoreValue >= 20)
        {
            Atoms.scoreValue -= 20;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Proton-Electron Combination", 1);
            }
        }
        else
        {
            CantAfford.gameObject.SetActive(true);
            StartCoroutine(HideCantAfford());
        }
    }
    public void BuyItem2()
    {
        if (Atoms.scoreValue >= 50)
        {
            Atoms.scoreValue -= 50;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Pressure Cooker", 1);
            }
        }
        else
        {
            CantAfford.gameObject.SetActive(true);
            StartCoroutine(HideCantAfford());
        }
    }
    public void BuyItem3()
    {
        if (Atoms.scoreValue >= 100)
        {
            Atoms.scoreValue -= 100;
            SetScore();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Atom Splitter", 1);
            }
        }
        else
        {
            CantAfford.gameObject.SetActive(true);
            StartCoroutine(HideCantAfford());
        }
    }
    public void BuyItem4()
    {
        if (Atoms.Temperature >= 10)
        {
            Atoms.Temperature -= 10;
            SetScoreTemp();
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Ionizer", 1);
            }
        }
        else
        {
            CantAfford.gameObject.SetActive(true);
            StartCoroutine(HideCantAfford());
        }
    }
    public void BuyItem5()
    {
        if (Atoms.Temperature >= 5000 && Atoms.Pressure >= 12)
        {
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.AddItem("Fusion Chamber", 1);
            }
        }
        else
        {
            CantAfford.gameObject.SetActive(true);
            StartCoroutine(HideCantAfford());
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
    public void UseItem5()
    {
    
        if (InventoryScript.canUse5)
        {
            FusionChamberScript.isFusionChamberActive = true;
            item5.SetActive(true);
            InventoryScript playerInventory = item.GetComponent<InventoryScript>();
            if (playerInventory != null)
            {
                playerInventory.RemoveItem("Fusion Chamber", 1);
            }
        }
        else
        {
            Debug.Log("You don't have this item in your inventory");
        }
        
        
    }

    void SetScore()
    {
        score.text = "Money: $" + Atoms.scoreValue;

    }
    void SetScoreTemp()
    {
        TemperatureTxt.text = "Temperature: " + Atoms.Temperature + "kK";
    }

}
