using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityExitScript : MonoBehaviour
{
    public EndActionCityScript EndActionCityScript;
    public Text ExitText;
    public GameObject player;

    private bool isInside;

    void Start()
    {
        isInside = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // TODO controller script ok?
        if (other.gameObject == player)
        {
            Debug.Log("OnTriggerEnter ControllerScript Trigger!");

            isInside = true;
            ExitText.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isInside = false;
        ExitText.enabled = false;
    }

    void Update()
    {
        if (isInside && OVRInput.GetDown(OVRInput.Button.Right))
        {
            Debug.Log("exit");
            ExitText.enabled = false;
            isInside = false;
            EndActionCityScript.EndAction();
        }
    }
}
