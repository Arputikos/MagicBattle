using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityResultScript : MonoBehaviour
{
    public TextMesh resultText;

    public StopwatchScript StopwatchScript;

    void Start()
    {
        resultText.text = "";
    }

    public void ShowShopResult()
    {
        System.TimeSpan time = StopwatchScript.GetTime();
        resultText.text = "Your time:\n" + time.Minutes.ToString() + "min  " + time.Seconds.ToString() + "sec\n";
    }
}
