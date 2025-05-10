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
    public Text score;
    public int curIonLevel = 50;
    public int maxIonLevel = 100;
    public Slider healthBar;



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
            isNeutron && collision.CompareTag("helium"))
        {
            Instantiate(Resources.Load("unstable-atom"), transform.position, Quaternion.identity);
            scoreValue -= 2;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Destroy(GameObject.Find("unstable-atom(Clone)"), 2f);
            SetIon(0);
            SetScore();
        }

        // Neutral Atom Combinations
        // Hydrogen Variants
        if (isProton && collision.CompareTag("electron"))
        {
            Instantiate(Resources.Load("hydrogen"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 5;
            SetScore();
            SetIon(1);
        }
        if (isNeutron && collision.CompareTag("hydrogen"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
        }
        if (isProton && collision.CompareTag("deuterium"))
        {
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(1);
        }

        // Helium Variants
        if (isNeutron && collision.CompareTag("hel3"))
        {
            Instantiate(Resources.Load("helium"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 5;
            SetScore();
            SetIon(1);
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
        }
        if (isNeutron && collision.CompareTag("lithium-6"))
        {
            Instantiate(Resources.Load("lithium7"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
        }
        if (isElectron && collision.CompareTag("lithium7"))
        {
            Instantiate(Resources.Load("lithium7--"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(1);
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
        }
        if (isElectron && collision.CompareTag("deuterium++"))
        {
            Instantiate(Resources.Load("hydrogen-2"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(2);
        }
        if (isElectron && collision.CompareTag("helium3++"))
        {
            Instantiate(Resources.Load("helium-3"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(2);
        }
        if (isElectron && collision.CompareTag("helium4++"))
        {
            Instantiate(Resources.Load("helium"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 1;
            SetScore();
            SetIon(2);
        }
        if (isProtonNeutron && collision.CompareTag("lithium7"))
        {
            Instantiate(Resources.Load("berillyum9++"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 3;
            SetScore();
            SetIon(2);
        }
        // Negative Ion Transformations
        if (isElectron && collision.CompareTag("hydrogen"))
        {
            Instantiate(Resources.Load("hydrogen1--"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 5;
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
        if (isHydrogen && collision.CompareTag("hydrogen") && Temperature >= 1000)
        {
            Instantiate(Resources.Load("helium"), transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            scoreValue += 10;
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
    public void BuyTemp200()
    {
        if (scoreValue >= 0)
        {
            Temperature += 200;
            //scoreValue -= 20;
            SetScoreTemp();
            SetScore();
        }
    }
    public void BuyTemp2k()
    {
        if (scoreValue >= 0)
        {
            Temperature += 2000;
            //scoreValue -= 50;
            SetScoreTemp();
            SetScore();
        }
    }
    

}


		