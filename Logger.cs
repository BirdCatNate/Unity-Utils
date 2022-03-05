using UnityEngine;

public enum LogMode
{
    none,
    fatal,
    error,
    warning,
    info,
    debug,
}

public static class Logger
{
    static string[] logColors = 
    {
        "#000000",  // none
        "#FF0000",  // fatal
        "#820000",  // error
        "#DAC400",  // warning
        "#0082FF",  // info
        "#A4A4A4",  // debug
    };

    public static void log(LogMode mode, LogMode filter, string message)
    {
        if( (int) mode > (int) filter ) return;

        string color = logColors[ (int) mode ];
        Debug.Log("<color=" + color + ">" + message + "</color>");
    }

    public static void log(LogMode mode, LogMode filter, string message, string source)
    {
        if( (int) mode > (int) filter ) return;


        string color = logColors[ (int) mode ];
        Debug.Log("<color=" + color + ">" + source + " | " + message + "</color>"); 
    }
}
