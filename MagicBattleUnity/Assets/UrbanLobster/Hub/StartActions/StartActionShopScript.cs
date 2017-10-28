using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StartActionShopScript : StartActionScript
{
    public ShoppingListManager ShoppingListManager;
    public ProductsInTheBasketManager ProductsInTheBasketManager;

    private int productCount;
    public void SetProductCount(int _productCount)
    {
        productCount = _productCount;
    }
    public override void StartAction()
    {
        // New Shopping List
        ShoppingList ShoppingListScript = ShoppingListManager.shoppingListScript;
        ShoppingListScript.GenerateNewShoppingList(productCount);
        ShoppingListManager.GenerateTextForShoppingList();
        ShoppingListManager.ShowShoppingList();

        // Empty Basket
        ProductsInTheBasket ProductsInTheBasket = ProductsInTheBasketManager.ProductsInTheBasketScript;
        ProductsInTheBasket.InitializeNewBasket();
        ProductsInTheBasketManager.GenerateNewTextForProductsInTheBasket();

        //
        Reset(prepareTime, ShoppingListManager.HideShoppingList);
    }
}