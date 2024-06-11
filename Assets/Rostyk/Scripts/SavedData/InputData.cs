using System.IO;
using UnityEngine;

namespace SavedData
{
    // серіалізуємий клас, який зберігає дані про клавіші
    [System.Serializable]
    public class InputData
    {
        private const string KEY = "InputData";         // ключ зберігання

        public KeyCode Crouch;                          // клавіша присідання
        public KeyCode Run;                             // клавіша бігу
        public KeyCode Jump;                            // клавіша стрибків
        public KeyCode Inventory;                       // клавіша інвентаря
        public KeyCode SwitchLight;                     // клавіша фонарика
        public KeyCode Shoot;                           // клавіша атаки
        public KeyCode Interact;                        // клавіша взаємодії
        public KeyCode Reload;                          // клавіша перезарядки
        public KeyCode SaveGame;                        // клавіша для збереження гри
        public KeyCode LoadGame;                        // клавіша для завантаження гри

        // конструктор по замовчуванню
        public InputData()
        {
            Crouch = KeyCode.LeftShift;
            Run = KeyCode.LeftControl;
            Jump = KeyCode.Space;
            Inventory = KeyCode.Tab;
            SwitchLight = KeyCode.F;
            Shoot = KeyCode.Mouse0;
            Interact = KeyCode.Mouse1;
            Reload = KeyCode.R;
            SaveGame = KeyCode.F1;
            LoadGame = KeyCode.F2;
        }

        // функція для збереження даних в файл по ключу
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        // функція для завантаження ігрових даних по ключу
        public InputData Load()
        {
            try
            {
                var data = StorageService.Load<InputData>(KEY);
                return data;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }
    }
}
