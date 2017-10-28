using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopClickableItem : ClickableItem
{
    public ProductsInTheBasket ProductsInTheBasket;
    public MarkerScript MarkerScript;

    private float maxDistanceToCollectObjects;
    Outline outline;

    void Start()
    {
        maxDistanceToCollectObjects = 3.0f;
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public override void Click(RaycastHit hit)
    {
        if (hit.distance > maxDistanceToCollectObjects)
            return;
        ProductsInTheBasket.AddItem(this.gameObject);
    }

    public override bool HighLightMaterial(float distance)
    {
        if (distance > maxDistanceToCollectObjects)
            return false;
        MarkerScript.SetSelectedItemType(SelectedItemType.Floor);
        outline.enabled = true;
        return true;
    }

    public override void UnHighLightMaterial()
    {
        outline.enabled = false;
    }
}