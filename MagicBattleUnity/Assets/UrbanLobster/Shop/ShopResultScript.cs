using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopResultScript : MonoBehaviour
{
    public TextMesh resultText;

    public ProductsInTheBasket ProductsInTheBasket;
    public ShoppingList ShoppingList;

    public StopwatchScript StopwatchScript;

    private Dictionary<ShopPickableItem.ProductName, int> productsInTheBasket;
    private Dictionary<ShopPickableItem.ProductName, int> productsOnTheList;

    void Start()
    {

        resultText.text = "";
    }

    public void ShowShopResult()
    {
        System.TimeSpan time = StopwatchScript.GetTime();
        string stringtime = time.Minutes.ToString() + "min  " + time.Seconds.ToString() + "sec\n";

        //TODO A shop result text
        productsOnTheList = ShoppingList.GetShoppingList();
        productsInTheBasket = ProductsInTheBasket.GetProductsInTheBasket();
        CompareDictionaries(stringtime);
    }


    void CompareDictionaries(string stringTime)
    {
        StringBuilder sb1 = new StringBuilder();
        sb1.Append(stringTime);
        sb1.Append("\n");
        sb1.Append("ok\n");
        if (!productsOnTheList.OrderBy(x => x.Key).SequenceEqual(productsInTheBasket.OrderBy(x => x.Key)))
        {
            StringBuilder sb2 = new StringBuilder();
            sb2.Append("not ok:\n");
            resultText.text = stringTime + ":(\n ";
            foreach (var item in productsInTheBasket)
            {
                if (productsOnTheList.ContainsKey(item.Key) && productsOnTheList[item.Key] == item.Value)
                {
                    sb1.Append(ItemTostring(item));
                    sb1.Append("\n");
                }
                else
                {
                    sb2.Append(ItemTostring(item));
                    if (productsOnTheList.ContainsKey(item.Key))
                        sb2.Append(" (must be " + productsOnTheList[item.Key] + ")\n");
                    else
                        sb2.Append(" (must be 0)\n");

                }
            }
            foreach (var item in productsOnTheList)
            {
                if (!productsInTheBasket.ContainsKey(item.Key))
                {
                    sb2.Append(item.Key.ToString());
                    sb2.Append(" x");
                    sb2.Append(0);
                    sb2.Append(" (must be " + productsOnTheList[item.Key] + ")\n");
                }
            }
            sb1.Append("\n\n");
            sb1.Append(sb2.ToString());
        }
        resultText.text = sb1.ToString();
    }

    private string ItemTostring(KeyValuePair<ShopPickableItem.ProductName, int> item)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(item.Key.ToString());
        sb.Append(" x");
        sb.Append(item.Value);
        return sb.ToString();
    }
}
