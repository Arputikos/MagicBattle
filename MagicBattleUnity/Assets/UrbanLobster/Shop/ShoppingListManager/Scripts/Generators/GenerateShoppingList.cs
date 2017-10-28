using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenerateShoppingList : MonoBehaviour {

    public abstract Dictionary<ShopPickableItem.ProductName, int> GenerateList(int count = 3);

}
