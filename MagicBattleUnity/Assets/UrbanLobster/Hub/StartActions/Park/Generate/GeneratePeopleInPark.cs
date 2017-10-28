using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class GeneratePeopleInPark : MonoBehaviour
{
    public RawImage rawImage;
    public PeopleInThePark PeopleInThePark;

    public abstract void Generate();

    protected void ShowPhoto(PersonScript person)
    {
        rawImage.texture = person.PhotoGO;
        rawImage.enabled = true;
    }

    public void HidePhoto()
    {
        rawImage.enabled = false;
    }
}
