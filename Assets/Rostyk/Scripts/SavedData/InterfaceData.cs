using System.IO;


namespace SavedData
{
    // серіалізуємий клас, який зберігає дані про інтерфейс та налаштування графіки
    [System.Serializable]
    public class InterfaceData
    {
        private const string KEY = "InterfaceData";         // ключ зберігання

        public bool isLightTheme;                           // дані про тему ігрового меню
        public bool isNegativeSensitivity;                  // дані про реверс осей миші
        public float CameraSensitivity;                     // дані про чутливість камери
        public float PlayerFar;                             // дані про дальність прорисовки

        // конструктор по замовчуванню
        public InterfaceData()
        {
            isLightTheme = false;
            isNegativeSensitivity = false;
            CameraSensitivity = 5;
            PlayerFar = 100;
        }

        // функція для збереження даних в файл по ключу
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        // функція для завантаження ігрових даних по ключу
        public InterfaceData Load()
        {
            try
            {
                var data = StorageService.Load<InterfaceData>(KEY);
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