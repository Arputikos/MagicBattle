using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniParserCity
{
    private Dictionary<string, Dictionary<string, string>> parserDictionary;

    public IniParserCity(Dictionary<string, Dictionary<string, string>> _parserDictionary)
    {
        parserDictionary = _parserDictionary;
    }

    public T Get<T>(string section, string parameter)
    {
        if (!parserDictionary.ContainsKey(section))
            throw new IniParserDictionaryDoesNotContainsKey("no section: " + section);
        else if (!parserDictionary[section].ContainsKey(parameter))
            throw new IniParserDictionaryDoesNotContainsKey("no parament: " + parameter);
        string value = parserDictionary[section][parameter];
        switch(parameter)
        {
            case ScenarioCitySettings.prepareTime:
                double prepareTimeValue;
                if (value.Contains(",") || !Double.TryParse(value, out prepareTimeValue))
                    throw new IniParserCantParseToDouble("cant parse: " + value);
                if (typeof(T) != typeof(double))
                    throw new IniParserGenericParameterIsNotCorrect(typeof(T).ToString());
                return (T)Convert.ChangeType(prepareTimeValue, typeof(T));
            default:
                throw new IniParserParameterIsNotDefined(parameter);
        }
    }
}
