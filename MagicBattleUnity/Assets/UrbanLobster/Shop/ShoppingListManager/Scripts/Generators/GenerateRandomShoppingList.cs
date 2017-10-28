using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomShoppingList : GenerateShoppingList
{
    public int LimitOfOneProduct;
    private int limitOperation = 100;
    private int nrOperation;
    private Dictionary<ShopPickableItem.ProductName, int> productsOnTheList;

    public override Dictionary<ShopPickableItem.ProductName, int> GenerateList(int countOfProducts)
    {
        productsOnTheList = new Dictionary<ShopPickableItem.ProductName, int>();
        nrOperation = 0;
        int i = 0;
        while (i < countOfProducts && nrOperation++ < limitOperation)
        {
            ShopPickableItem.ProductName item = ((ShopPickableItem.ProductName)Random.Range(0, System.Enum.GetValues(typeof(ShopPickableItem.ProductName)).Length));
            if (productsOnTheList.ContainsKey(item))
            {
                if (productsOnTheList[item] < LimitOfOneProduct)
                {
                    productsOnTheList[item]++;
                    i++;
                }
            }
            else
            {
                productsOnTheList.Add(item, 1);
                i++;
            }
        }
        return productsOnTheList;
    }
}
