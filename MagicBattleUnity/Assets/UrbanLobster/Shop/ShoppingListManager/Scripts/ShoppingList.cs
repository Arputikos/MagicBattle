using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour {

	public GenerateShoppingList GeneratorOfShoppingList;

	private Dictionary<ShopPickableItem.ProductName,int> shoppingListDictionary;

    public void GenerateNewShoppingList(int count)
    {
		shoppingListDictionary = GenerateList (count);
    }
    
    private Dictionary<ShopPickableItem.ProductName,int> GenerateList(int count){
		return GeneratorOfShoppingList.GenerateList (count);
	}

	public  Dictionary<ShopPickableItem.ProductName,int> GetShoppingList(){
		return shoppingListDictionary;
	}
}
