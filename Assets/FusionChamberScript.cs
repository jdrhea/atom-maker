using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FusionChamberScript : MonoBehaviour
{
    public static bool isFusionChamberActive = false; // Flag to check if the fusion chamber is active
    bool canFuse = true; // Flag to check if fusion can occur
    public GameObject atomScript; // Reference to the Fusion Chamber GameObject

    void Update()
    {
        if (Atoms.Temperature >= 10000 && Atoms.Pressure >= 9 && isFusionChamberActive)
        {
            canFuse = true; // Set canFuse to true if conditions are met
        }
        else
        {
            canFuse = false; // Reset canFuse if conditions are not met     
        }
    }
    public void OnFusionButtonClick()
    {
        if (canFuse)
        {
            Atoms a = atomScript.GetComponent<Atoms>();
            if (a != null)
            {
                a.FuseAtoms(); // Call the method to fuse atoms
            }
        }
        else
        {
            Debug.Log("Fusion conditions not met!"); // Log message if conditions are not met
        }
    }

}
