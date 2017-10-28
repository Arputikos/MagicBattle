using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class InitParserShopTest
{
    IniParserShop iniParserShop;
    private Dictionary<string, Dictionary<string, string>> iniContentCorrectDict = new Dictionary<string, Dictionary<string, string>>
        {
            { "Shop.Easy", new Dictionary<string, string>() { { "ProductCount", "5" }, { "PrepareTime", "5.5" } } }
        };
    private Dictionary<string, Dictionary<string, string>> iniContentIncorrectDict0 = new Dictionary<string, Dictionary<string, string>>
        {
            { "Shop.Easy", new Dictionary<string, string>() { { "ProductCount", " a5" }, { "PrepareTime", "5,5" } } }
        };
    private Dictionary<string, Dictionary<string, string>> iniContentIncorrectDict1 = new Dictionary<string, Dictionary<string, string>>
        {
            { "Shop.Easy", new Dictionary<string, string>() { { "ProductCount", " 5 5" }, { "PrepareTime", "5 5" } } }
        };
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ShopParse_IntGetNoException()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.DoesNotThrow(() => iniParserShop.Get<int>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.productCount));
    }
    [Test]
    public void ShopParse_IntGet_DictionaryDoesNotContainsKeyException0()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.Throws<IniParserDictionaryDoesNotContainsKey>(() => iniParserShop.Get<int>(ScenarioShopSettings.ShopEasy + "A", ScenarioShopSettings.productCount));
    }
    [Test]
    public void ShopParse_IntGet_DictionaryDoesNotContainsKeyException()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.Throws<IniParserDictionaryDoesNotContainsKey>(() => iniParserShop.Get<int>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.productCount + "A"));
    }
    [Test]
    public void ShopParse_IntGet_GenericParameterIsNotCorrectException()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.Throws<IniParserGenericParameterIsNotCorrect>(() => iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.productCount));
    }
    [Test]
    public void ShopParse_IntGet_CantParseToIntException0()
    {
        iniParserShop = new IniParserShop(iniContentIncorrectDict0);
        Assert.Throws<IniParserCantParseToInt>(() => iniParserShop.Get<int>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.productCount));
    }
    [Test]
    public void ShopParse_IntGet_CantParseToIntException1()
    {
        iniParserShop = new IniParserShop(iniContentIncorrectDict1);
        Assert.Throws<IniParserCantParseToInt>(() => iniParserShop.Get<int>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.productCount));
    }
    [Test]
    public void ShopParse_IntGet_CorrectReturnValue()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.AreEqual(iniParserShop.Get<int>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.productCount), 5);
    }

    [Test]
    public void ShopParse_DoubleGetNoException()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.DoesNotThrow(() => iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.prepareTime));
    }
    [Test]
    public void ShopParse_DoubleGet_DictionaryDoesNotContainsKeyException0()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.Throws<IniParserDictionaryDoesNotContainsKey>(() => iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy + "A", ScenarioShopSettings.prepareTime));
    }
    [Test]
    public void ShopParse_DoubleGet_DictionaryDoesNotContainsKeyException()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.Throws<IniParserDictionaryDoesNotContainsKey>(() => iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.prepareTime + "A"));
    }
    [Test]
    public void ShopParse_DoubleGet_GenericParameterIsNotCorrectException()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.Throws<IniParserGenericParameterIsNotCorrect>(() => iniParserShop.Get<float>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.prepareTime));
    }
    [Test]
    public void ShopParse_DoubleGet_CantParseToDoubleException0()
    {
        iniParserShop = new IniParserShop(iniContentIncorrectDict0);
        Assert.Throws<IniParserCantParseToDouble>(() => iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.prepareTime));
    }
    [Test]
    public void ShopParse_DoubleGet_CantParseToDoubleException1()
    {
        iniParserShop = new IniParserShop(iniContentIncorrectDict1);
        Assert.Throws<IniParserCantParseToDouble>(() => iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.prepareTime));
    }
    [Test]
    public void ShopParse_DoubleGet_CorrectReturnValue()
    {
        iniParserShop = new IniParserShop(iniContentCorrectDict);
        Assert.AreEqual(iniParserShop.Get<double>(ScenarioShopSettings.ShopEasy, ScenarioShopSettings.prepareTime), 5.5);
    }
}
