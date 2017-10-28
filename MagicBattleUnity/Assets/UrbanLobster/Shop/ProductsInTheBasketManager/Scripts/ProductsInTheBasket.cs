using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ProductsInTheBasket : MonoBehaviour
{
    public ProductsInTheBasketManager ProductsInTheBasketManager;
    public HiddenProducts HiddenProducts;

    private AudioSource audioSource;
    private Dictionary<ShopPickableItem.ProductName, int> productsInTheBasket;

    private AudioClip soundName;

    void Start()
    {
        productsInTheBasket = new Dictionary<ShopPickableItem.ProductName, int>();
        audioSource = GetComponent<AudioSource>();
        soundName = GetComponent<AudioClip>();
        audioSource.enabled = true;
    }

    public void InitializeNewBasket()
    {
        productsInTheBasket = new Dictionary<ShopPickableItem.ProductName, int>();
    }

    public void AddItem(GameObject product)
    {
        var item = product.GetComponent<ShopPickableItem>().Name;
        audioSource.Play();
        if (productsInTheBasket.ContainsKey(item))
            productsInTheBasket[item]++;
        else
            productsInTheBasket.Add(item, 1);
        ProductsInTheBasketManager.GenerateNewTextForProductsInTheBasket();
        HiddenProducts.HideProduct(ref product);
    }

    private void PlayOneShot(AudioSource audioSource)
    {
        throw new NotImplementedException();
    }

    public Dictionary<ShopPickableItem.ProductName, int> GetProductsInTheBasket()
    {
        return productsInTheBasket;
    }
}

