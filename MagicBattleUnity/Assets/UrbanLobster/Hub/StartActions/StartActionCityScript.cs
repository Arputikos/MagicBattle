using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActionCityScript : StartActionScript
{
    public StartFinishPointsManager StartFinishPointsManager;
    public GameObject Compass;

    public override void StartAction()
    {
        StartFinishPointsManager.ShowMap();
        Compass.SetActive(true);
        Reset(prepareTime, StartFinishPointsManager.HideMapShowExit);
        //Reset(prepareTime, null);
    }
}
