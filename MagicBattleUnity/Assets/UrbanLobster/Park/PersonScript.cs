using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonScript : MonoBehaviour {

    public GameObject PersonGO;
    public Texture  PhotoGO;

    public GameObject CreatePerson(Transform transform, bool choosen=false)
    {
        GameObject go = Instantiate(PersonGO, transform);

        if (choosen && go.GetComponent<ParkClickableItem>() == null)
            Debug.Log("null");
        else
            go.GetComponent<ParkClickableItem>().SetChoosen(choosen);
        return go;
    }

}
