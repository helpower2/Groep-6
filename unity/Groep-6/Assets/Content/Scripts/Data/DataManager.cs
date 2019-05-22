using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataManager
{
    public static string dataPath = Application.persistentDataPath;

    public static void Save<T>(T file, object fileName)
    {
        try
        {
            string data = JsonUtility.ToJson(file);
            File.WriteAllText(dataPath + "/" + fileName + ".json", data);
            Debug.Log(dataPath + "/" + fileName + ".json");
        }
        catch(Exception e)
        {
            Debug.LogError("Save Failed: " + e.Message + ", " + e.HelpLink);
            throw;
        }
    }
    public static void Load<T>(ref T _param, string _name)
    {
        try
        {
            string data = File.ReadAllText(dataPath + "/" + _name + ".json");
            _param = JsonUtility.FromJson<T>(data);
        }
        catch
        {
            Debug.Log("Loading Failed: " + _param.ToString());
            Save(_param, _name);
            Load(ref _param, _name);
        }
        
    }
}
