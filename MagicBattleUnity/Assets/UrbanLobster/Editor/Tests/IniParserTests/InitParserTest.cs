using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using UnityEngine;

public class IniParserTest
{
    private StreamReader iniContent;
    private StreamReader inccorectIniContent;
    private Dictionary<string, Dictionary<string, string>> iniContentCorrectDict;
    private Dictionary<string, Dictionary<string, string>> iniContentIncorrectDict;

    [SetUp]
    public void Setup()
    {
        string iniContentStr =
            "[Shop.Easy]\n " +
            "ProductCount = 5\n" +
            "PrepareTime =  5.5\n";
        iniContentCorrectDict = new Dictionary<string, Dictionary<string, string>>
        {
            { "Shop.Easy", new Dictionary<string, string>() { { "ProductCount", "5" }, { "PrepareTime", "5.5" } } }
        };
        iniContentIncorrectDict = new Dictionary<string, Dictionary<string, string>>
        {
            { "Shop.Easy", new Dictionary<string, string>() { { "ProductCount", "5" }, { "PrepareTime", " 5.5" } } }
        };
        string inccorectIniContentStr =
            "[Shop.Easy]\n " +
            "ProductCount 5\n" +
            "PrepareTime = 5.5";

        MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(iniContentStr));
        iniContent = new StreamReader(stream);

        stream = new MemoryStream(Encoding.ASCII.GetBytes(inccorectIniContentStr));
        inccorectIniContent = new StreamReader(stream);
    }

    [Test]
    public void Parse_NoException()
    {
        IniParser iniParser = new IniParser();
        Assert.DoesNotThrow(() => iniParser.Parse(iniContent));
    }

    [Test]
    public void Parse_IncorrectContentSyntax_ThrowsException()
    {
        IniParser iniParser = new IniParser();
        Assert.Throws<IniParserSyntaxException>(() => iniParser.Parse(inccorectIniContent));
    }

    [Test]
    public void Parse_CompareToCorrectDictionary()
    {
        IniParser iniParser = new IniParser();
        Assert.IsTrue(CheckDictionary(iniContent, iniContentCorrectDict));
    }

    [Test]
    public void Parse_CompareToIncorrectDictionary()
    {
        IniParser iniParser = new IniParser();
        Assert.IsFalse(CheckDictionary(iniContent, iniContentIncorrectDict));
    }

    public bool CheckDictionary(StreamReader sr, Dictionary<string, Dictionary<string, string>> dict)
    {
        IniParser iniParser = new IniParser();
        bool result = true;
        Dictionary<string, Dictionary<string, string>> parserDict = iniParser.Parse(sr);
        foreach (KeyValuePair<string, Dictionary<string, string>> item in parserDict)
        {
            foreach (KeyValuePair<string, string> subItem in parserDict[item.Key])
            {
                if (!dict.ContainsKey(item.Key) || !dict[item.Key].ContainsKey(subItem.Key) || dict[item.Key][subItem.Key] != subItem.Value)
                {
                    result = false;
                    break;
                }
            }
            if (!result)
                break;
        }
        return result;
    }
}
