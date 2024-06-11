using System.IO;
using UnityEngine;


// Клас для збереження та завантаження будь-яких даних по шляху:
// (C:\Users\user\AppData\LocalLow\PaniniGames\Darkness in the depths\ + [KEY])
public static class StorageService
{
    // збереження даних у файл
    public static void Save(string key, object data)
    {
        // отримуємо шлях, за яким будемо зберігати дані
        string path = GetBuildPath(key);
        // конвертуємо ігрові дані в Json
        string jsonData = JsonUtility.ToJson(data);

        // використовуємо StreamWriter для створення файлу
        using (var fileStream = new StreamWriter(path))
        {
            fileStream.Write(jsonData);
        }
    }

    // завантаження даних у файл
    public static T Load<T>(string key)
    {
        // отримуємо шлях, за яким потрібно дістати дані
        string path = GetBuildPath(key);
        string jsonData;

        // використовуємо StreamWriter для зчитки файлу
        using (var fileStream = new StreamReader(path))
        {
            jsonData = fileStream.ReadToEnd();
            var data = JsonUtility.FromJson<T>(jsonData);

            return data;
        }
    }

    // побудова шляху збереження або завантаження файлу
    private static string GetBuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}
