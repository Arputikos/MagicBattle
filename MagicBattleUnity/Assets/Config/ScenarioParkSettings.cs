using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioParkSettings
{
    public const string ParkEasy = "Park.Easy";
    public const string ParkMedium = "Park.Medium";
    public const string ParkHard = "Park.Hard";

   // public const string productCount = "PeopleCount";
    public const string prepareTime = "PrepareTime";

    public struct ParkDifficultyStruct
    {
        public double PrepareTime;
    }
    private ParkDifficultyStruct Easy;
    private ParkDifficultyStruct Medium;
    private ParkDifficultyStruct Hard;

    public ScenarioParkSettings() { }

    public void SetSettings(IniParserPark iniParserPark)
    {
        try
        {
            Easy.PrepareTime = iniParserPark.Get<double>(ParkEasy, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Easy.PrepareTime = 0;
        }
        
        try
        {
            Medium.PrepareTime = iniParserPark.Get<double>(ParkMedium, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Medium.PrepareTime = 0;
        }
        
        try
        {
            Hard.PrepareTime = iniParserPark.Get<double>(ParkHard, prepareTime);
        }
        catch (IniParserDictionaryDoesNotContainsKey e)
        {
            Debug.Log(e.Message);
            Hard.PrepareTime = 0;
        }
    }

    public ParkDifficultyStruct GetSettings(LevelOfDifficulty.Level level)
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
