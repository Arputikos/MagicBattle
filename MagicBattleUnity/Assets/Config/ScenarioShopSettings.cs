using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioShopSettings
{
    public const string ShopEasy = "Shop.Easy";
    public const string ShopMedium = "Shop.Medium";
    public const string ShopHard = "Shop.Hard";

    public const string productCount = "ProductCount";
    public const string prepareTime = "PrepareTime";

    public struct ShopDifficultyStruct
    {
        public int ProductCount;
        public double PrepareTime;
    }
    private ShopDifficultyStruct Easy;
    private ShopDifficultyStruct Medium;
    private ShopDifficultyStruct Hard;

    public ScenarioShopSettings() { }

    public void SetSettings(IniParserShop iniParserShop)
    {
        try
        {
            Easy.ProductCount = iniParserShop.Get<int>(ShopEasy, productCount);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Easy.ProductCount = 0;
        }
        try
        {
            Easy.PrepareTime = iniParserShop.Get<double>(ShopEasy, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Easy.PrepareTime = 0;
        }

        try
        {
            Medium.ProductCount = iniParserShop.Get<int>(ShopMedium, productCount);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Medium.ProductCount = 0;
        }
        try
        {
            Medium.PrepareTime = iniParserShop.Get<double>(ShopMedium, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Medium.PrepareTime = 0;
        }

        try
        {
            Hard.ProductCount = iniParserShop.Get<int>(ShopHard, productCount);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Hard.ProductCount = 0;
        }
        try
        {
            Hard.PrepareTime = iniParserShop.Get<double>(ShopHard, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Hard.PrepareTime = 0;
        }
    }

    public ShopDifficultyStruct GetSettings(LevelOfDifficulty.Level level)
    {
        switch (level)
        {
            case LevelOfDifficulty.Level.Easy:
                return Easy;
            case LevelOfDifficulty.Level.Medium:
                return Medium;
            case LevelOfDifficulty.Level.Hard:
                return Hard;
            default:
                throw new System.NotImplementedException();
        }
    }
}
