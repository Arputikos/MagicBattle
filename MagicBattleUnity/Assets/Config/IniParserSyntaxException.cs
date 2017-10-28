using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class IniParserSyntaxException : Exception
{
    public IniParserSyntaxException(string message) : base(message){}
}

public class IniParserDictionaryDoesNotContainsKey : Exception
{
    public IniParserDictionaryDoesNotContainsKey(string message) : base(message) { }
}

public class IniParserCantParseToInt : Exception
{
    public IniParserCantParseToInt(string message) : base(message) { }
}

public class IniParserCantParseToDouble : Exception
{
    public IniParserCantParseToDouble(string message) : base(message) { }
}

public class IniParserParameterIsNotDefined : Exception
{
    public IniParserParameterIsNotDefined(string message) : base(message) { }
}

public class IniParserGenericParameterIsNotCorrect : Exception
{
    public IniParserGenericParameterIsNotCorrect(string message) : base(message) { }
}
