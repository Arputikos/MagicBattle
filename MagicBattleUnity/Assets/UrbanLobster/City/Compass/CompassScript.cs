using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    public GameObject compass;

    void Start()
    {
        compass.SetActive(false);
    }

    void Update()
    {
        //TODO A change update on event
        if (OVRInput.GetDown(OVRInput.Button.Left))
        {
            compass.SetActive(!compass.activeSelf);
        }
    }
}
