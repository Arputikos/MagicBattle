using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SimpleShoppingListManager : ShoppingListManager
{
	public Text ShoppingListText;

    private Dictionary<ShopPickableItem.ProductName, int> productsOnTheList;

    private void Start()
    {
        HideShoppingList();
    }

	public override void GenerateTextForShoppingList()
	{
        productsOnTheList = shoppingListScript.GetShoppingList();
		ShoppingListText.text = GenerateTextFromDictionary ();
	}

	string GenerateTextFromDictionary(){
		StringBuilder sb = new StringBuilder();
		sb.Append ("Shopping List:\n");
		foreach (var item in productsOnTheList) {
			sb.Append(item.Key.ToString());
			sb.Append(" x");
			sb.Append(item.Value);
			sb.Append("\n");
		}
		return sb.ToString ();
	}

    public override void ShowShoppingList()
    {
        ShoppingListText.enabled = true;
    }

    public override void HideShoppingList()
    {
        ShoppingListText.enabled = false;
    }
}
