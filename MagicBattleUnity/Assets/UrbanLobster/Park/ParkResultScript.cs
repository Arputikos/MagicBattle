using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParkResultScript : MonoBehaviour
{
    public TextMesh resultText;
    public StopwatchScript StopwatchScript;

    private bool ChoosenPerson;

    void Start()
    {
        resultText.text = "";
    }

    public void ChoosenPersonOK()
    {
        ChoosenPerson = true;
    }

    public void ShowParkResult()
    {
        System.TimeSpan time = StopwatchScript.GetTime();
        string stringTime = time.Minutes.ToString() + "min  " + time.Seconds.ToString() + "sec\n";
        if (ChoosenPerson)
        {
            resultText.text = stringTime + "ok";
        }
        else
        {
            resultText.text = stringTime + ":(";
        }
        ChoosenPerson = false;
    }
}
