using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject neutronPrefab;
    public GameObject protonPrefab;
    public GameObject electronPrefab;
    public Vector3 newPosition;
    public Quaternion NewRotation;

    void Start()
    {
        //this.GetComponent<Drag>().enabled=true;
    }

    public void InstantiateNeutron()
    {
        Instantiate(neutronPrefab,newPosition,NewRotation);
        //this.GetComponent<Drag>().enabled=false;
    }
    public void InstantiateProton()
    {
        Instantiate(protonPrefab,newPosition,NewRotation);
        //this.GetComponent<Drag>().enabled=false;
    }
    public void InstantiateElectron()
    {
        Instantiate(electronPrefab,newPosition,NewRotation);
        //this.GetComponent<Drag>().enabled=false;
    }



}
