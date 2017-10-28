using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProductsInTheBasketOnClickManager : MonoBehaviour
{
    public ProductsInTheBasket ProductsInTheBasket;

    public abstract void Generate(Dictionary<ShopPickableItem.ProductName, int> ProductsOnTheList);
}
