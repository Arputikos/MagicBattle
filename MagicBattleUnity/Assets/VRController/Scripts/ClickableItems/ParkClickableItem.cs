using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkClickableItem : ClickableItem
{
    public float maxDistanceToCollectObjects = 10.0f;

    //TODO A private 
    public delegate void ClickAction();
    public event ClickAction OnClicked;
    public event ClickAction ClickedItemOk;

    private bool choosen;
    private List<Outline> outlines;

    private void Start()
    {
        outlines = new List<Outline>();
        FindOutline();
        SetOutline(false);
    }

    public ClickAction OnClickedAction()
    {
        return OnClicked;
    }

    public void SetChoosen(bool _bool)
    {
        choosen = _bool;
    }

    public override void Click(RaycastHit hit)
    {
        if (hit.distance > maxDistanceToCollectObjects)
            return;
        if (this.choosen)
            ClickedItemOk();
        OnClicked();
    }

    Color initColor;
    Color highLightColor = new Color(1, 0, 0);
    GameObject selectedItem;

    public override bool HighLightMaterial(float distance)
    {
        if (distance > maxDistanceToCollectObjects)
            return false;
        SetOutline(true);
        return true;
    }

    public override void UnHighLightMaterial()
    {
        SetOutline(false);
    }


    private void FindOutline()
    {
        Outline outline;
        if ((outline = GetComponent<Outline>()) != null)
        {
            outlines.Add(outline);
        }

        foreach (Transform child in transform)
        {
            FindOutlineRec(child);
        }
    }

    int count = 0;
    private void FindOutlineRec(Transform child)
    {
       // if (count > 10)
       //     Application.Quit();
        foreach (Transform grandchildchild in child.transform)
        {
            FindOutlineRec(grandchildchild);
        }

        Outline outline;
        if ((outline = child.GetComponent<Outline>()) != null)
        {
            outlines.Add(outline);
        }
    }

    private void SetOutline(bool isAcitive)
    {
        foreach(Outline outline in outlines)
        {
            outline.enabled = isAcitive;
        }
    }
}
