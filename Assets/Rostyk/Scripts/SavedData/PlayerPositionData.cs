using System.IO;
using UnityEngine;

namespace SavedData
{
    // серіалізуємий клас, який зберігає дані про позицію та кут повороту гравця
    [System.Serializable]
    public class PlayerPositionData
    {
        private const string KEY = "PlayerPositionData";    // ключ зберігання

        public Vector3 position;                            // дані про позицію гравця в просторі
        public Quaternion rotation;                         // дані про кут повороту гравця

        // конструктор по замовчуванню
        public PlayerPositionData(Vector3 DefaultPos = new())
        {
            position = DefaultPos;
            rotation = Quaternion.identity;
        }

        // функція для збереження даних в файл по ключу
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        // функція для завантаження ігрових даних по ключу
        public PlayerPositionData Load()
        {
            try
            {
                var newData = StorageService.Load<PlayerPositionData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }
    }
}