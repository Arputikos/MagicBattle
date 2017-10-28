using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ShoppingListManager : MonoBehaviour {

    public ShoppingList shoppingListScript;

    /*private void Start()
    {
        HideShoppingListEvent = new UnityEvent();
        HideShoppingListEvent.AddListener(HideShoppingList);
    }*/

    public abstract void GenerateTextForShoppingList();
    public abstract void ShowShoppingList();
    public abstract void HideShoppingList();
}
