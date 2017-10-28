using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndActionShopScript : EndActionsScript
{
    public HiddenProducts HiddenProducts;
    public ShopResultScript ShopResultScript;
    public Text ProductsInTheBasketText;

    public override void EndAction()
    {
        StopwatchScript.StopStopwatch();
        HiddenProducts.ActivateProducts();
        ProductsInTheBasketText.text = "";
        ShopResultScript.ShowShopResult();
        TransitionToHubScript.StartTransition();
    }
}
