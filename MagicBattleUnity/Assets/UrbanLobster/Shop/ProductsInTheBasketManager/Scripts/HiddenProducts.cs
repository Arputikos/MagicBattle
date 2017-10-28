using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenProducts : MonoBehaviour
{
    private List<GameObject> gameObjects;

    void Start()
    {
        gameObjects = new List<GameObject>();
    }

    public void HideProduct(ref GameObject product)
    {
        product.SetActive(false);
        gameObjects.Add(product);
    }

    public void ActivateProducts()
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(true);
        }
    }
}
