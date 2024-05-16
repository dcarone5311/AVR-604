using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLog : MonoBehaviour
{
    public Text logText;
    public static ScreenLog Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (!Instance)
            Instance = this;

    }
    void Start()
    {
        logText.text = "";
    }

    private void _log(string msg)
    {
        if (logText)
            logText.text += msg + "\n";
    }

    public static void Log(string msg)
    {
        if (Instance)
            Instance._log(msg);
        Debug.Log(msg);
    }
}
