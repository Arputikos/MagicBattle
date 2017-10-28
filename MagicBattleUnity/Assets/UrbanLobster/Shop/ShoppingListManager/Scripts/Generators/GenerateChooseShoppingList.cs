using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ShoppingLIstChooseDictionary{
	public ShopPickableItem.ProductName ProductName;
	public int Count;
}

public class GenerateChooseShoppingList : GenerateShoppingList {

	public ShoppingLIstChooseDictionary[] ShoppingList;
	//public List<ShopPickableItem.ProductName> listWithProducts;

	private Dictionary<ShopPickableItem.ProductName, int> productsOnTheList;

	public override Dictionary<ShopPickableItem.ProductName,int> GenerateList(int count){
		
		productsOnTheList = new Dictionary<ShopPickableItem.ProductName, int> ();

		foreach (ShoppingLIstChooseDictionary item in ShoppingList) {
			
			if (productsOnTheList.ContainsKey (item.ProductName)) {
				productsOnTheList [item.ProductName] += item.Count;
			} else {
				productsOnTheList.Add (item.ProductName, item.Count);
			}
		}
		return productsOnTheList;
	}
}
