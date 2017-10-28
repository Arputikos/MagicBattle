using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorClickableItem : ClickableItem
{
    public ControllerTeleport ControllerTeleport;
    public MarkerScript MarkerScript;

    private float maxDistance;
    Vector3 positionToTeleport;
    float epsilon;
    Quaternion rotationToTeleport;

    private void Start()
    {
        maxDistance = 40.0f;
        epsilon = 0.1f;

        if (ControllerTeleport == null)
        {
              Debug.Log("Controller is null");
        }
        else
        {
            //TODO A null exeption

            if (MarkerScript == null)
                Debug.Log("MarkerScript  null");

        }
        rotationToTeleport = new Quaternion();
    }


    public override void Click(RaycastHit hit)
    {
        if (hit.distance > maxDistance)
            return;
        //MarkerScript.SetSelectedItemType(SelectedItemType.Floor);

        positionToTeleport = hit.point;
        // TODO A epsilon??
        positionToTeleport = new Vector3(positionToTeleport.x, positionToTeleport.y + epsilon, positionToTeleport.z);
        ControllerTeleport.Teleport(positionToTeleport, null, null);
    }


    public override bool HighLightMaterial(float distance)
    {
        if (distance<maxDistance)
            MarkerScript.SetSelectedItemType(SelectedItemType.Floor);
        return false;
    }

    public override void UnHighLightMaterial() { }
}
