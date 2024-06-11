using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SavedData
{
    // серіалізуємий клас, який зберігає дані про знищені ігрові об'єкти на сцені
    [System.Serializable]
    public class TriggerData
    {
        private const string KEY = "TriggerData";       // ключ зберігання

        public bool[] IsDestroyedObject;                // дані про знищені ігрові об'єкти на сцені

        // конструктор
        public TriggerData(List<GameObject> TriggerList)
        {
            IsDestroyedObject = new bool[TriggerList.Count];
        }

        // функція для збереження даних в файл по ключу
        public void Save(List<GameObject> Enemies)
        {
            StorageService.Save(KEY, this);
        }

        // функція для завантаження ігрових даних по ключу
        public TriggerData Load(List<GameObject> TriggerList)
        {
            try
            {
                var newData = StorageService.Load<TriggerData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save(TriggerList);
                return this;
            }
        }
    }
}