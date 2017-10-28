using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProductsInTheBasketOnHandManager : MonoBehaviour {

    public abstract void Generate(Dictionary<ShopPickableItem.ProductName, int> ProductsIntheBasket);
}
