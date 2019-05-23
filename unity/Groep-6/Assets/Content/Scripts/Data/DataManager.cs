using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class DataManager
{
    public static string dataPath = Application.persistentDataPath;

    public static void Save<T>(T file, object fileName) where T : struct
    {
        try
        {
            string data = JsonUtility.ToJson(file);
            //Debug.Log("data: " + data);
            File.WriteAllText(dataPath + "/" + fileName + ".json", data);
            //Debug.Log(dataPath + "/" + fileName + ".json");
        }
        catch(Exception e)
        {
            Debug.LogError("Save Failed: " + e.Message + ", " + e.HelpLink);
            throw;
        }
    }
    public static void Load<T>(ref T _param, string _name, int count = 0) where T : struct
    {
        try
        {
            string data = File.ReadAllText(dataPath + "/" + _name + ".json");
            //Debug.Log("data: " + data);
            _param = JsonUtility.FromJson<T>(data);
            //Debug.Log(dataPath + "/" + _name + ".json");
        }
        catch (Exception e)
        {
            Debug.Log("Loading Failed: " + e.Message);
            Save(_param, _name);
            Load(ref _param, _name, count++);
        }
        
    }
}
public static class DataExtensions
{
    public static void Save<T>(this T file, string _name) where T : struct
    {
        DataManager.Save(file, _name);
    }
    public static void load<T>(this T _param, string _name) where T : struct
    {
        DataManager.Load(ref _param, _name);
    }
    public static void Save<T>(this T file) where T : struct
    {
        DataManager.Save(file, typeof(T).Name);
    }
    public static void load<T>(this T _param) where T : struct
    {
        DataManager.Load(ref _param, typeof(T).Name);
    }
} 
