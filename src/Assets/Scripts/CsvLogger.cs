using System.Collections;
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
        path = "Logs/GameLog_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
        csvString = new StringBuilder();
        csvString.AppendLine($"time,message,beeId");
        csvString.AppendLine($"{DateTime.Now:s},logger initialized,0");
    }

    public void Message(string message, int beeId = 0)
    {
        csvString.AppendLine($"{DateTime.Now:s},{message},{beeId}");
    }
    
    public void SaveToFile()
    {
        File.AppendAllText(path, csvString.ToString());
    }
}
