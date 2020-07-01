using System;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class Repl
{
    [DllImport("libUnityRepl")]
    public static extern int init();

    [DllImport("libUnityRepl")]
    [return: MarshalAs(UnmanagedType.BStr)]
    public static extern string getline();
}

public class REPL : MonoBehaviour
{
    protected void Awake()
    {
        Repl.init();
        var output = new StreamWriter(Console.OpenStandardOutput());
        output.AutoFlush = true;
        Console.SetOut(output);
        Application.logMessageReceived += OnLogMessageReceived;
    }
    private void LogConsole(string message, LogType logType)
    {
        if (string.IsNullOrEmpty(message)) return;
        switch (logType)
        {
            case LogType.Error:
            case LogType.Assert:
            case LogType.Exception:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case LogType.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

        Console.WriteLine(message);
        Console.ResetColor();
    }

    private void OnLogMessageReceived(string logMessage, string stackTrace, LogType logType)
    {
        LogConsole(logMessage, logType);
        if (logType == LogType.Error)
            LogConsole(stackTrace, logType);
    }

    public void Update()
    {
        var str = Repl.getline();
        if (!string.IsNullOrEmpty(str))
        {
            //Debug.Log(str);
            // luaState.DoString(str);
        }
    }
    protected virtual void OnDestroy()
    {
        Application.logMessageReceived -= OnLogMessageReceived;
    }
}
