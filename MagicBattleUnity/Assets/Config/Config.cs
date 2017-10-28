using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private IniReader iniReader;
    private IniParser iniParser;
    private IniParserShop iniParserShop;
    private IniParserPark iniParserPark;
    private IniParserCity iniParserCity;

    private ScenarioShopSettings scenarioShopSettings;
    private ScenarioParkSettings scenarioParkSettings;
    private ScenarioCitySettings scenarioCitySettings;


    public ScenarioShopSettings GetScenarioShopSettings()
    {
        return scenarioShopSettings;
    }
    public ScenarioParkSettings GetScenarioParkSettings()
    {
        return scenarioParkSettings;
    }
    public ScenarioCitySettings GetScenarioCitySettings()
    {
        return scenarioCitySettings;
    }


    public void Reload()
    {
        iniReader = new IniReader();
        iniParser = new IniParser();

        iniParserShop = new IniParserShop(iniParser.Parse(iniReader.ReadIni()));
        scenarioShopSettings = new ScenarioShopSettings();
        scenarioShopSettings.SetSettings(iniParserShop);

        iniParserPark = new IniParserPark(iniParser.Parse(iniReader.ReadIni()));
        scenarioParkSettings = new ScenarioParkSettings();
        scenarioParkSettings.SetSettings(iniParserPark);

        iniParserCity = new IniParserCity(iniParser.Parse(iniReader.ReadIni()));
        scenarioCitySettings = new ScenarioCitySettings();
        scenarioCitySettings.SetSettings(iniParserCity);
    }

    void Start()
    {
        Reload();
    }
}
