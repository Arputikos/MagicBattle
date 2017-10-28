using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubClickableItem : ClickableItem {

    public GameObject BackgroundLighting;

    public override void Click(RaycastHit hit)
    {
        return;
    }

    public override bool HighLightMaterial(float distance)
    {
        BackgroundLighting.SetActive(true);
        return true;
    }

    public override void UnHighLightMaterial()
    {
        BackgroundLighting.SetActive(false);
    }
}
