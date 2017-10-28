using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

public class IniParser
{
    const string beginSection = "[";
    const string endSection = "]";
    const string comment = ";";
    const char equals = '=';

    public IniParser(){}

    public Dictionary<string, Dictionary<string, string>> Parse(StreamReader sr)
    {
        Dictionary<string, Dictionary<string, string>> parserDictionary = new Dictionary<string, Dictionary<string, string>>();
        string line = "";
        string section = "";

        Dictionary<string, string> sectionDictionary = new Dictionary<string, string>();
        while ((line = sr.ReadLine())!=null)
        {
            line.Trim();
            if (line.StartsWith(comment) || line=="")
                continue;
            else if (line.StartsWith(beginSection) && line.EndsWith(endSection))
            {
                section = line.Substring(1, line.Length - 2);
                sectionDictionary = new Dictionary<string, string>();
                parserDictionary.Add(section, sectionDictionary);
            }
            else
            {
                string[] ln = line.Split(equals);
                string key = ln[0].Trim();
                if (ln.Length == 1 || section == "" || key == "")
                {
                    throw new IniParserSyntaxException("error at: " + line);
                }
                string value = ln[1].Trim();
                //Debug.Log("add " + section + " " + key + " " + value);
                parserDictionary[section].Add(key, value);
            }
        }
        return parserDictionary;
    }

}
