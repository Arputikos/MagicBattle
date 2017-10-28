using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EndActionsScript : MonoBehaviour
{
    public TransitionToHubScript TransitionToHubScript;
    public StopwatchScript StopwatchScript;
    //public ControllerTeleport ControllerTeleport;
    //public Transform hubCenter;

    public abstract void EndAction();

}
