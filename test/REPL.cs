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
    }
    public void Update()
    {
        var str = Repl.getline();
        if (!string.IsNullOrEmpty(str))
        {
            Debug.Log(str);
            // luaState.DoString(str);
        }
    }
}
