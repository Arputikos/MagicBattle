using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndActionCityScript : EndActionsScript
{
    public CityResultScript CityResultScript;
    public GameObject Exit;
    public GameObject Compass;

    public override void EndAction()
    {
        StopwatchScript.StopStopwatch();
        Exit.SetActive(false);
        Compass.SetActive(false);
        CityResultScript.ShowShopResult();
        TransitionToHubScript.StartTransition();
    }
}
