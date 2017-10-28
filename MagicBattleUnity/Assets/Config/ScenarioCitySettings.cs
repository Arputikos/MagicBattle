using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioCitySettings
{
    public const string CityEasy = "City.Easy";
    public const string CityMedium = "City.Medium";
    public const string CityHard = "City.Hard";

    public const string prepareTime = "PrepareTime";

    public struct CityDifficultyStruct
    {
        public double PrepareTime;
    }

    private CityDifficultyStruct Easy;
    private CityDifficultyStruct Medium;
    private CityDifficultyStruct Hard;

    public ScenarioCitySettings() { }

    public void SetSettings(IniParserCity iniParserCity)
    {
        try
        {
            Easy.PrepareTime = iniParserCity.Get<double>(CityEasy, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Easy.PrepareTime = 0;
        }

        try
        {
            Medium.PrepareTime = iniParserCity.Get<double>(CityMedium, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Medium.PrepareTime = 0;
        }

        try
        {
            Hard.PrepareTime = iniParserCity.Get<double>(CityHard, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Hard.PrepareTime = 0;
        }
    }

        public CityDifficultyStruct GetSettings(LevelOfDifficulty.Level level)
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
