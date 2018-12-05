using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    public static string AssetBundlesPath = "Assets/AssetBundles";
    [HideInInspector]
    public Prefab[] prefabs;

    private string dataPath = "Assets/Resources/data.json";

    void Start()
    {   
        //prefabs = new Prefab[3];
        //prefabs[0] = new Prefab();
        //prefabs[0].Name = "cube";
        //prefabs[1] = new Prefab();
        //prefabs[1].Name = "capsule";
        //prefabs[2] = new Prefab();
        //prefabs[2].Name = "sphere";
        //SaveDataToJSON();

        LoadDataFromJSON();
    }

    private void LoadDataFromJSON()
    {
        if (File.Exists(dataPath))
        {
            string dataAsJson = File.ReadAllText(dataPath); 
            prefabs = JsonHelper.FromJson<Prefab>(dataAsJson);

        }
    }

    //private void SaveDataToJSON()
    //{
    //    string dataAsJson = JsonHelper.ToJson(prefabs, true);
    //    Debug.Log(dataAsJson);
    //    File.WriteAllText(dataPath, dataAsJson);
    //}
    
}
[Serializable]
public class Prefab
{
    public string Name;
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Names;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Names = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Names = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Names;
    }
}