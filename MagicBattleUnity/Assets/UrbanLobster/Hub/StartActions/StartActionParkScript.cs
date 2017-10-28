using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartActionParkScript : StartActionScript
{
    public GeneratePeopleInPark GeneratePeopleInPark;

    public override void StartAction()
    {
        GeneratePeopleInPark.Generate();
        Reset(prepareTime, GeneratePeopleInPark.HidePhoto);
    }
}
