using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class CollectiongObjectsLeapMotion : MonoBehaviour
{
    public ProductsInTheBasket ProductsInTheBasketListScript;

    void OnTriggerStay(Collider other)
    {
        var script = other.gameObject.GetComponent<InteractionBehaviour>();
        if (script == null)
            return;

        var scriptWithName = other.gameObject.GetComponent<ShopPickableItem>();
        if (script.isGrasped)
        {
            //ProductsInTheBasketListScript.AddItem (scriptWithName.Name, ref other.gameObject);

            // TODO A destroy ?
            //other.gameObject.active = false;
            //DestroySafe(other.gameObject);

            //other.gameObject.SetActive (false);
        }
    }

    private void DestroySafe(GameObject gameObject)
    {
        gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
}