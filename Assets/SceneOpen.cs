using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOpen : MonoBehaviour
{
    
    public void OpenAtomCreation()
    {
        // Load the AtomMaker scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("AtomCreation");
    }
    public void OpenMoleculeCreation()
    {
        // Load the MoleculeMaker scene
        //UnityEngine.SceneManagement.SceneManager.LoadScene("MoleculeMaker");
    }
}
