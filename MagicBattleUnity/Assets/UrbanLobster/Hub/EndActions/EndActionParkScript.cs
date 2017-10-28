using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndActionParkScript : EndActionsScript
{
    public PeopleInThePark PeopleInThePark;
    public ParkResultScript ParkResultScript;

    public override void EndAction()
    {
        StopwatchScript.StopStopwatch();
        PeopleInThePark.DeactivatePeople();
        TransitionToHubScript.StartTransition();
        ParkResultScript.ShowParkResult();
        //ControllerTeleport.Teleport(hubCenter.position, ParkResultScript.ShowParkResult);
    }
}
