﻿using System;
using System.IO;
using UnityEngine;

public class SavingToFile : IStorageService
{
    // сохранение данных
    public void Save(string key, object data, Action<bool> callback = null)
    {
        string path = GetBuildPath(key);
        string jsonData = JsonUtility.ToJson(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(jsonData);
        }

        callback?.Invoke(true);
    }

    // загрузка данных
    public void Load<T>(string key, Action<T> callback)
    {
        string path = GetBuildPath(key);
        string jsonData;

        using (var fileStream = new StreamReader(path))
        {
            jsonData = fileStream.ReadToEnd();
            var data = JsonUtility.FromJson<T>(jsonData);

            callback.Invoke(data);
        }
    }

    // построение пути
    private string GetBuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}