using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class TeleportMarkerController : MonoBehaviour
{
    public Camera cameraVR;
    public GameObject marker;
    //public MarkerScript MarkerScript;
    public float maxDistance;
    public float maxDistanceToCollectObjects;

    Vector3 screenCenterVector;
    GameObject lastFrameHitObject;
    MarkerScript MarkerScript;

    // Use this for initialization
    void Start()
    {
        MarkerScript = marker.GetComponent<MarkerScript>();
        if (MarkerScript == null)
            Debug.Log("MarkerScript is null");
        marker.SetActive(true);
        screenCenterVector = new Vector3(0.5F, 0.5F, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cameraVR.ViewportPointToRay(screenCenterVector);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

        bool raycast = Physics.Raycast(ray, out hit, Mathf.Infinity, ~(1<<8));
        //bool raycast = Physics.Raycast(ray, out hit);

        if (!raycast)
            return;
        
        marker.transform.position = hit.point;
        if (hit.distance > maxDistance)
        {
            MarkerScript.SetSelectedItemType(SelectedItemType.Other);
            return;
        }

        GameObject hitObject = hit.transform.gameObject;
        ClickableItem ClickableItem = hitObject.GetComponent<ClickableItem>();
        if (ClickableItem != null)
        {
            MarkerScript.SetSelectedItemType(SelectedItemType.ClickableItem);
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                //ewentualne wracanie do norm koloru
                CheckReturnToInitialColor();
                ClickableItem.Click(hit);
            }
            else
            {
                //podswietlenie itemu
                //jesli byl jakis inny podswitlony to wrocic go do norm koloru
                if (hitObject != lastFrameHitObject)
                {
                    //ewentualne wracanie poprzedniego do normalnego koloru
                    CheckReturnToInitialColor();
                    //podswietlenie nowego
                    if (ClickableItem.HighLightMaterial(hit.distance))
                        lastFrameHitObject = hitObject;
                }
            }
        }
        else //not clickable item
        {
            MarkerScript.SetSelectedItemType(SelectedItemType.Other);
            //ewentualne wracanie do norm koloru
            CheckReturnToInitialColor();
        }
    }

    private void CheckReturnToInitialColor()
    {
        if (lastFrameHitObject != null)
        {
            lastFrameHitObject.GetComponent<ClickableItem>().UnHighLightMaterial();
            lastFrameHitObject = null;
        }
    }
}
