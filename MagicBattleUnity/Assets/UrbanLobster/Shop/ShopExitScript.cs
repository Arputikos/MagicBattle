using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopExitScript : MonoBehaviour
{
    public EndActionShopScript EndActionShopScript;
    public Text ExitText;
    public GameObject player;

    private bool isInside;

    void Start()
    {
        isInside = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ControllerScript>()!=null)
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
            EndActionShopScript.EndAction();
        }
    }
}
