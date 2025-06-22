using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private Vector3 offset;

    //public GameObject proton;
    // public GameObject electron;
    public bool isProton;
    public bool isNeutron;
    public bool isElectron;
    public bool isProtonNeutron;
    public bool islithium6;
    public bool isHydrogen;
    public bool isRadioactive;

    public static int scoreValue = 0;
    public static int Temperature = 1;

    public TMP_Text TemperatureTxt;
    public TMP_Text AtomCreationTxt;
    public Text score;
    public int curIonLevel = 50;
    public int maxIonLevel = 100;
    public Slider healthBar;
    public GameObject clone;



    private void Awake()
    {
        GameObject scoreObject = GameObject.Find("skoer");

        if (scoreObject != null)
        {
            score = scoreObject.GetComponent<Text>();

        }
        GameObject sliderObject = GameObject.Find("IonSlider");

        if (sliderObject != null)
        {
            healthBar = sliderObject.GetComponent<Slider>();

        }
        GameObject tempObject = GameObject.Find("Temperature");

        if (tempObject != null)
        {
            TemperatureTxt = tempObject.GetComponent<TMP_Text>();

        }
        GameObject createText = GameObject.Find("Creation");

        if (createText != null)
        {
            AtomCreationTxt = createText.GetComponent<TMP_Text>();

        }


    }
    void Update()
    {
        if (dragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

        }
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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
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

        }
        if (isNeutron && collision.CompareTag("hydrogen"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Hydrogen-2 (Deuterium)");
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
        }
        // Boron Variants
        if (isElectron && collision.CompareTag("boron10++"))
        {
            Instantiate(Resources.Load("boron10"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
            YouHaveCreatedAtom("Boron-10");
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
        }
        if (isProton && collision.CompareTag("hydrogen2--"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(0);
        }
        if (isProton && collision.CompareTag("helium3--"))
        {
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(0);
        }

        // Fusion Reactions
        if (isHydrogen && collision.CompareTag("hydrogen") && Temperature >= 100000)
        {
            Instantiate(Resources.Load("helium"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 100;
            SetScore();
            SetIon(0);
        }


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
    public void BuyTemp2k()
    {
        if (scoreValue >= 50)
        {
            Temperature += 2000;
            scoreValue -= 50;
            SetScoreTemp();
            SetScore();
        }
    }
    

}


		