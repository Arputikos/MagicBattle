using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum SelectedItemType { Floor, ClickableItem, Other };

public class MarkerScript : MonoBehaviour
{
    
    public Material floorMarkerMaterial;
    public Material pickableItemMarkerMaterial;
    public Material otherMarkerMaterial;

    private SelectedItemType selectedItemType;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public SelectedItemType GetSelectedItemType()
    {
        return selectedItemType;
    }

    public void SetSelectedItemType(SelectedItemType SelectedItemType)
    {
        if (selectedItemType == SelectedItemType)
            return;

        switch (SelectedItemType)
        {
            case SelectedItemType.Floor:
                rend.material = floorMarkerMaterial;
                break;
            case SelectedItemType.ClickableItem:
                rend.material = pickableItemMarkerMaterial;
                break;
            default:
                rend.material = otherMarkerMaterial;
                break;
        }
        selectedItemType = SelectedItemType;
    }
}

