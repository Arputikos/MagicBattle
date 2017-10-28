using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniParserShop
{
    private Dictionary<string, Dictionary<string, string>> parserDictionary;

    public IniParserShop(Dictionary<string, Dictionary<string, string>> _parserDictionary)
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
        switch (parameter)
        {
            case ScenarioShopSettings.productCount:
                int productCountValue;
                if (!Int32.TryParse(value, out productCountValue))
                    throw new IniParserCantParseToInt("cant parse: " + value);
                if (typeof(T) != typeof(int))
                    throw new IniParserGenericParameterIsNotCorrect(typeof(T).ToString());
                return (T)Convert.ChangeType(productCountValue, typeof(T));
            case ScenarioShopSettings.prepareTime:
                string parameterString = value;
                double prepareTimeValue;
                if (parameterString.Contains(",") || !Double.TryParse(parameterString, out prepareTimeValue))
                    throw new IniParserCantParseToDouble("cant parse: " + parameterString);
                if (typeof(T) != typeof(double))
                    throw new IniParserGenericParameterIsNotCorrect(typeof(T).ToString());
                return (T)Convert.ChangeType(prepareTimeValue, typeof(T));
            default:
                throw new IniParserParameterIsNotDefined(parameter);
        }
    }
}
