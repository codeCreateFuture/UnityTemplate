using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMgr : MonoBehaviour,ILogHandler {

    public void LogException(Exception exception, UnityEngine.Object context)
    {
     
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
       
    }

    private void Awake()
    {
        Debug.unityLogger.logEnabled = true;
        Debug.unityLogger.logHandler = this;
        Application.logMessageReceived += OnLogReceived;
    }

    private void OnLogReceived(string condition, string stackTrace, LogType type)
    {
       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
