using System;
using System.IO;
using UnityEngine;

// Класс для сохранения и загрузки любых данных по пути:
// (C:\Users\user\AppData\LocalLow\DefaultCompany\Darkness in the depths\ + [KEY])
public static class StorageService
{
    // сохранение данных
    public static void Save(string key, object data)
    {
        string path = GetBuildPath(key);
        string jsonData = JsonUtility.ToJson(data);

        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(jsonData);
        }
    }

    // загрузка данных
    public static T Load<T>(string key)
    {
        string path = GetBuildPath(key);
        string jsonData;

        using (var fileStream = new StreamReader(path))
        {
            jsonData = fileStream.ReadToEnd();
            var data = JsonUtility.FromJson<T>(jsonData);

            return data;
        }
    }

    // построение пути
    private static string GetBuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
