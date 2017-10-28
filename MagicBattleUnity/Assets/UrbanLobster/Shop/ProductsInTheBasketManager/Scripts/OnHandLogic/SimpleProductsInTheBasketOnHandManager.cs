using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SimpleProductsInTheBasketOnHandManager : ProductsInTheBasketOnHandManager {

	public TextMesh text;

	public override void Generate(Dictionary<ShopPickableItem.ProductName, int> ProductsInTheBasket){

		StringBuilder sb = new StringBuilder();
		sb.Append ("Products In The Basket\n");
		foreach (var item in ProductsInTheBasket) {
			sb.Append(item.Key.ToString());
			sb.Append(" x");
			sb.Append(item.Value);
			sb.Append("\n");
		}
		text.text = sb.ToString ();
	}
}
