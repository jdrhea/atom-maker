using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atoms : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    //public GameObject proton;
    // public GameObject electron;
    public bool isProton;
    public bool isNeutron;
    public bool isElectron;
    public bool isProtonNeutron;
    public bool isProtonElectron;
    public bool islithium6;
    public bool isHydrogen;
    public bool isRadioactive;

    public static int scoreValue = 0;
    public static int Temperature = 1;
    public static int Pressure = 1;
    public static int AtomsFound = 0;

    public TMP_Text TemperatureTxt;
    public TMP_Text AtomCreationTxt;
    public TMP_Text PressureTxt;
    public Text score;
    public Text AmountOfAtomsTxt;   
    public int curIonLevel = 50;
    public int maxIonLevel = 100;
    public Slider healthBar;
    public GameObject clone;

    Vector3 newPosition;



    private void Awake()
    {
        GameObject scoreObject = GameObject.Find("skoer");

        if (scoreObject != null)
        {
            score = scoreObject.GetComponent<Text>();

        }
        // Find the Slider component in the scene

        GameObject sliderObject = GameObject.Find("IonSlider");
        if (sliderObject != null)
        {
            healthBar = sliderObject.GetComponent<Slider>();

        }
        // Find the TMP_Text component for temperature and atom creation text
        GameObject tempObject = GameObject.Find("Temperature");
        if (tempObject != null)
        {
            TemperatureTxt = tempObject.GetComponent<TMP_Text>();

        }
        // Find the TMP_Text component for atom creation text
        GameObject createText = GameObject.Find("Creation");
        if (createText != null)
        {
            AtomCreationTxt = createText.GetComponent<TMP_Text>();

        }
        // Find the TMP_Text component for pressure text
        GameObject pressureText = GameObject.Find("Pressure");
        if (pressureText != null)
        {
            PressureTxt = pressureText.GetComponent<TMP_Text>();

        }
        // Find the TMP_Text component for amount of atoms text
        GameObject foundText = GameObject.Find("AtomsFound");
        if (foundText != null)
        {
            AmountOfAtomsTxt = foundText.GetComponent<Text>();

        }
    }
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

        }
        SetScoreTemp();
        SetPressure();
    }
    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragging = true;
    }
    void OnMouseUp()
    {
        dragging = false;
        //transform.position = new Vector2(0,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("toolbox"))
        {
            Destroy(gameObject);
            Debug.Log("I have collided with toolbox");
        }
        if (collision.CompareTag("atomSplitter") && isRadioactive)
        {
            // Instantiate explosion animation at the atom's position
            GameObject explosion = Instantiate(Resources.Load("explosion"), transform.position, Quaternion.identity) as GameObject;
            // Optionally destroy the explosion after its animation duration (e.g., 2 seconds)
            Destroy(explosion, 2f);
            Instantiate(Resources.Load("Electron_Example"), transform.position, Quaternion.identity);
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreValue += 100;
            SetScore();
            YouHaveCreatedAtom("You have split an atom!");
            AmountOfAtoms(1);
        }

        // Ionizing Atoms
        if (collision.CompareTag("ionizer") && CompareTag("hydrogen") ||
        collision.CompareTag("ionizer") && CompareTag("hydrogen1--") ||
        collision.CompareTag("ionizer") && CompareTag("deuterium") ||
        collision.CompareTag("ionizer") && CompareTag("hydrogen2--"))
        {
            // Instantiate ionized hydrogen atom
            Instantiate(Resources.Load("plus-ion-hydrogen"), transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreValue += 50;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Ionized Hydrogen");
            AmountOfAtoms(1);
        }
        if (collision.CompareTag("ionizer") && CompareTag("helium") ||
        collision.CompareTag("ionizer") && CompareTag("hel3") ||
        collision.CompareTag("ionizer") && CompareTag("helium3--") ||
        collision.CompareTag("ionizer") && CompareTag("helium4--"))
        {
            // Instantiate ionized helium atom
            Instantiate(Resources.Load("ionized-helium"), transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreValue += 50;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Ionized Helium");
            AmountOfAtoms(1);
        }
        if (collision.CompareTag("ionizer") && CompareTag("lithium-6") ||
        collision.CompareTag("ionizer") && CompareTag("lithium6--") ||
        collision.CompareTag("ionizer") && CompareTag("lithium7") ||
        collision.CompareTag("ionizer") && CompareTag("lithium7--"))
        {
            // Instantiate ionized lithium atom
            Instantiate(Resources.Load("ionized-lithium"), transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreValue += 50;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Ionized Lithium");
            AmountOfAtoms(1);
        }
        if (collision.CompareTag("ionizer") && CompareTag("berillyum9"))
        {
            // Instantiate ionized berillyum atom
            Instantiate(Resources.Load("ionized-berillyum"), transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreValue += 50;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Ionized Berillyum");
            AmountOfAtoms(1);
        }
        if (collision.CompareTag("ionizer") && CompareTag("boron10") ||
        collision.CompareTag("ionizer") && CompareTag("boron11"))
        {
            // Instantiate ionized boron atom
            Instantiate(Resources.Load("ionized-boron"), transform.position, Quaternion.identity);
            Destroy(gameObject);
            scoreValue += 50;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Ionized Boron");
            AmountOfAtoms(1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Handle collisions with other atoms :)
        // Unstable Atoms
        if (isNeutron && collision.CompareTag("electron") ||
            isNeutron && collision.CompareTag("deuterium") ||
            isNeutron && collision.CompareTag("helium") ||
            isNeutron && collision.CompareTag("berillyum9") ||
            isNeutron && collision.CompareTag("boron11"))
        {
            Instantiate(Resources.Load("unstable-atom"), transform.position, Quaternion.identity);
            scoreValue -= 2;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            SetIon(0);
            SetScore();
            YouHaveCreatedAtom("An Unstable Atom");
            AmountOfAtoms(1);
        }
        if (isRadioactive)
        {
            Destroy(clone.gameObject, 3f);
        }

        // Neutral Atom Combinations
        // Hydrogen Variants
        if (isProton && collision.CompareTag("electron"))
        {
            Instantiate(Resources.Load("hydrogen"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Hydrogen");
            AmountOfAtoms(1);

        }
        if (isNeutron && collision.CompareTag("hydrogen") || isNeutron && collision.CompareTag("p-e combination"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Hydrogen-2 (Deuterium)");
            AmountOfAtoms(1);
        }
        if (isProton && collision.CompareTag("deuterium"))
        {
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Helium-3");
            AmountOfAtoms(1);
        }
        if (isProtonElectron && collision.CompareTag("proton"))
        {
            Instantiate(Resources.Load("hydrogen1--"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 10;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Hydrogen-1 Negative Ion");
            AmountOfAtoms(1);
        }
        // Helium Variants
        if (isNeutron && collision.CompareTag("hel3"))
        {
            Instantiate(Resources.Load("helium"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Helium");
            AmountOfAtoms(1);
        }
        if (isProtonElectron && collision.CompareTag("p&n"))
        {
            Instantiate(Resources.Load("helium3++"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 10;
            SetScore();
            SetIon(2);
            YouHaveCreatedAtom("Helium-3 plus ion");
            AmountOfAtoms(1);
        }

        // Lithium Variants
        if (isProtonNeutron && collision.CompareTag("helium"))
        {
            Instantiate(Resources.Load("lithium6"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Lithium-6");
            AmountOfAtoms(1);
        }
        if (isNeutron && collision.CompareTag("lithium-6"))
        {
            Instantiate(Resources.Load("lithium7"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Lithium-7");
            AmountOfAtoms(1);
        }
        if (isElectron && collision.CompareTag("lithium7"))
        {
            Instantiate(Resources.Load("lithium7--"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Lithium-7 Negative Ion");
            AmountOfAtoms(1);
        }
        // Berillyum Variants
        if (isElectron && collision.CompareTag("berillyum9++"))
        {
            Instantiate(Resources.Load("berillyum9"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Berillyum-9");
            AmountOfAtoms(1);
        }
        if (isProton && collision.CompareTag("berillyum9"))
        {
            Instantiate(Resources.Load("boron10++"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(2);
            YouHaveCreatedAtom("Boron-10++");
            AmountOfAtoms(1);
        }
        // Positive Ion Transformations
        if (isProton && collision.CompareTag("neutron"))
        {
            Instantiate(Resources.Load("plus-ion-hydrogen2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(2);
            YouHaveCreatedAtom("Hydrogen-2 plus ion");
            AmountOfAtoms(1);
        }
        if (isElectron && collision.CompareTag("deuterium++"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Deuterium (Hydrogen-2)");
            AmountOfAtoms(1);
        }
        if (isElectron && collision.CompareTag("helium3++"))
        {
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Helium-3");
            AmountOfAtoms(1);
        }
        if (isElectron && collision.CompareTag("helium4++"))
        {
            Instantiate(Resources.Load("helium"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Helium");
            AmountOfAtoms(1);
        }
        if (isProtonNeutron && collision.CompareTag("lithium7"))
        {
            Instantiate(Resources.Load("berillyum9++"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(2);
            YouHaveCreatedAtom("Beryllium-9++");
            AmountOfAtoms(1);
        }
        if (isProton && collision.CompareTag("berillyum9"))
        {
            Instantiate(Resources.Load("boron10++"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(2);
            YouHaveCreatedAtom("Boron-10 plus ion");
            AmountOfAtoms(1);
        }
        // Boron Variants
        // first two are the same output
        if (isElectron && collision.CompareTag("boron10++"))
        {
            Instantiate(Resources.Load("boron10"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Boron-10");
            AmountOfAtoms(1);
        }
        if (isProtonElectron && collision.CompareTag("berillyum9"))
        {
            Instantiate(Resources.Load("boron10"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 10;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Boron-10");
            AmountOfAtoms(1);
        }
        if (isNeutron && collision.CompareTag("boron10"))
        {
            Instantiate(Resources.Load("boron11"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Boron-11");
            AmountOfAtoms(1);
        }
        // Negative Ion Transformations
        if (isElectron && collision.CompareTag("hydrogen"))
        {
            Instantiate(Resources.Load("hydrogen1--"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Hydrogen-1 Negative Ion");
            AmountOfAtoms(1);
        }
        if (isProton && collision.CompareTag("hydrogen2--"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Deuterium (Hydrogen-2)");
            AmountOfAtoms(1);
        }
        if (isProton && collision.CompareTag("helium3--"))
        {
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(0);
            YouHaveCreatedAtom("Helium-3");
            AmountOfAtoms(1);
        }


    }
    public void FuseAtoms()
    {
        GameObject[] hydrogen = GameObject.FindGameObjectsWithTag("hydrogen");

        if (hydrogen.Length >= 2)
        {

            // Destroy the two hydrogen atoms
            Destroy(hydrogen[0]);
            Destroy(hydrogen[1]);

            // Instantiate helium
            Instantiate(Resources.Load("helium"), newPosition, Quaternion.identity);

            // Update score and UI
            scoreValue += 100;
            SetScore();
            YouHaveCreatedAtom("helium through fusion!");
        }
        else
        {
            Debug.Log("Not enough deuterium atoms for fusion!");
        }
        AmountOfAtoms(1);

    }
    void SetScore()
    {
        score.text = "Money: $" + scoreValue;

    }
    public void SetIon(int SetIon)
    {
        curIonLevel = SetIon;
        curIonLevel = Mathf.Clamp(curIonLevel, 0, maxIonLevel); // Ensure the value stays within bounds
        healthBar.value = curIonLevel;
    }
    void SetScoreTemp()
    {
        TemperatureTxt.text = "Temperature: " + Temperature + "kK";
    }
    public void YouHaveCreatedAtom(string GameObject)
    {
        AtomCreationTxt.text = "You Have Created:" + GameObject;
    }
    public void SetPressure()
    {
        PressureTxt.text = "Pressure: 10^" + Pressure + "atm";
    }
    public void BuyTemp200()
    {
        if (scoreValue >= 20)
        {
            Temperature += 200;
            scoreValue -= 20;
            SetScoreTemp();
            SetScore();
        }
    }
    public void AmountOfAtoms(int found)
    {
        AtomsFound += found;
        AmountOfAtomsTxt.text = "Atoms: " + AtomsFound;
    }
    

}


