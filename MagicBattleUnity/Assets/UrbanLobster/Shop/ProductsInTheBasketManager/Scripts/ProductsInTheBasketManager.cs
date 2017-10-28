using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProductsInTheBasketManager : MonoBehaviour
{
    public ProductsInTheBasket ProductsInTheBasketScript;

    private Dictionary<ShopPickableItem.ProductName, int> productsIntheBasket;

    public ProductsInTheBasketOnHandManager OnHand;
    public ProductsInTheBasketOnClickManager OnClick;

    public void GenerateNewTextForProductsInTheBasket()
    {
        productsIntheBasket = ProductsInTheBasketScript.GetProductsInTheBasket();
        OnClick.Generate(productsIntheBasket);
        // 
        if (OnHand != null)
            OnHand.Generate(productsIntheBasket);
    }
}
