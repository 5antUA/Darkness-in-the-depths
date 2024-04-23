using UnityEngine;

public static class SaveManager
{
    public static void Save<Type>(string key, Type data)
    {
        // конвертируем данные в json и закидуем в память компьютера
        string jsonData = JsonUtility.ToJson(data, true);
        PlayerPrefs.SetString(key, jsonData);
    }

    public static Type Load<Type>(string key) where Type: new()
    {
        // если в памяти компьютера есть ключ...
        if (PlayerPrefs.HasKey(key))
        {
            string jsonData = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<Type>(jsonData);
        }
        // если нет, то используем данные по умолчанию
        else
        {
            return new();
        }
    }

    public static void Delete(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
