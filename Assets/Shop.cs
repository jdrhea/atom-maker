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
     // Helper method to hide CantAfford image after 2 seconds
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

    void SetScore()
    {
        score.text = "Money: $" + Atoms.scoreValue;

    }
    void SetScoreTemp()
    {
        TemperatureTxt.text = "Temperature: " + Atoms.Temperature + "kK";
    }

}
