using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PressureCookerScript : MonoBehaviour
{
    public TMP_Text setPressureText;
    public TMP_Text setTemperatureText;

    private int pressure = 0; // Current pressure in the cooker
    private int temperature = 0; // Current temperature in the cooker

    void Update()
    {
        Atoms.Pressure = pressure;
        Atoms.Temperature = temperature;
    }

    public void IncreasePressure()
    {
        pressure += 1; // Increase pressure by 1 unit
        UpdatePressureText();
    }
    public void DecreasePressure()
    {
        if (pressure > 0)
        {
            pressure -= 1; // Decrease pressure by 1 unit
            UpdatePressureText();
        }
    }
    public void IncreaseTemperature()
    {
        temperature += 1000; // Increase temperature by 1000 units
        UpdateTemperatureText();
    }
    public void DecreaseTemperature()
    {
        if (temperature > 0)
        {
            temperature -= 1000; // Decrease temperature by 1000 units
            UpdateTemperatureText();
        }
    }   
    public void UpdateTemperatureText()
    {
        setTemperatureText.text = temperature + " kK";
    }

    public void UpdatePressureText()
    {
        setPressureText.text = "10^" + pressure + " atm";
    }

}
