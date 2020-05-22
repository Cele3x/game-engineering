﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

public class CsvLogger : MonoBehaviour
{
    public string path;
    public StringBuilder csvString;

    // Start is called before the first frame update
    void Start()
    {
        path = "GameLog_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
    }

    public void Message(string message, int beeId = 0)
    {
        if(csvString == null) Initialize();
        csvString.AppendLine($"{DateTime.Now:s},{message},{beeId}");
    }

    private void Initialize()
    {
        csvString = new StringBuilder();
        csvString.AppendLine($"time,message,beeId");
        csvString.AppendLine($"{DateTime.Now:s},logger initialized,0");
    }
    
    public void SaveToFile()
    {
        File.AppendAllText(path, csvString.ToString());
    }
}
