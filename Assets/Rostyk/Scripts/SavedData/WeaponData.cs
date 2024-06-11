using System.IO;


namespace SavedData
{
    // серіалізуємий клас, який зберігає дані про підняту зброю
    [System.Serializable]
    public class WeaponData
    {
        private const string KEY = "WeaponData";        // ключ зберігання
        public bool[] Weapons;                          // дані про підняту зброю

        // конструктор по замовчуванню
        public WeaponData()
        {
            Weapons = new bool[3];
            Weapons[0] = true;
        }

        // функція для збереження даних в файл по ключу
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        // функція для завантаження ігрових даних по ключу
        public WeaponData Load()
        {
            try
            {
                var newData = StorageService.Load<WeaponData>(KEY);
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