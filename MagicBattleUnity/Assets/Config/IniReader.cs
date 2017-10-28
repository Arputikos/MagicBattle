using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IniReader
{
    private const string iniPath = @"\Assets\Config\Settings.ini";

    public IniReader() { }

    public StreamReader ReadIni()
    {
        string fullPath = System.Environment.CurrentDirectory + iniPath;
        if (File.Exists(fullPath))
        {
            return new StreamReader(fullPath);
        }
        else
        {
            //TODO A change to not open level
            throw new FileNotFoundException();
        }
    }
}
