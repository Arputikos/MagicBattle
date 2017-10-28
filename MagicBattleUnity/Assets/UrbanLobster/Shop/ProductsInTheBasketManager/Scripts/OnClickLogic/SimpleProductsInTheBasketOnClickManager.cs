using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SimpleProductsInTheBasketOnClickManager : ProductsInTheBasketOnClickManager
{
    public Text ProductsInTheBasketText;

    public override void Generate(Dictionary<ShopPickableItem.ProductName, int> ProductsInTheBasket)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Products In The Basket:\n");

        foreach (var item in ProductsInTheBasket)
        {
            sb.Append(item.Key.ToString());
            sb.Append(" x");
            sb.Append(item.Value);
            sb.Append("\n");
        }
        ProductsInTheBasketText.text = sb.ToString();
    }

    void Update()
    {
        //TODO A change update on event
        if (OVRInput.GetDown(OVRInput.Button.Left))
        {
            ProductsInTheBasketText.enabled = !ProductsInTheBasketText.enabled;
        }
    }
}
