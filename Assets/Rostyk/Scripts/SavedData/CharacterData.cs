using RostykEnums;
using System.IO;


namespace SavedData
{
    // серіалізуємий клас, який зберігає дані про персонажа
    [System.Serializable]
    public class CharacterData
    {
        private const string KEY = "CharacterData";         // ключ зберігання

        public bool isContinueGame;                         // якщо гра продовжується...
        public Characters Character;                        // персонаж
        public Properties Property;                         // характеристики персонажа

        // конструктор по замовчуванню
        public CharacterData()
        {
            isContinueGame = false;
            Property = null;
        }

        // функція для збереження даних в файл по ключу
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        // функція для завантаження ігрових даних по ключу
        public CharacterData Load()
        {
            try
            {
                var newData = StorageService.Load<CharacterData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }


        #region Characters
        // Слабкий, але швидкий
        public Properties KovalevProperty = new Properties()
        {
            MaxCharacterHealth = 75,
            Health = 75,
            Damage = 0.7f,
            WalkSpeed = 4,
            SprintSpeed = 4,
            CrouchSpeed = 3,
        };

        // Золотая середина
        public Properties ValentinProperty = new Properties()
        {
            MaxCharacterHealth = 100,
            Health = 100,
            Damage = 1,
            WalkSpeed = 3,
            SprintSpeed = 4,
            CrouchSpeed = 2,
        };

        // Сильний, але повільний
        public Properties RomarioProperty = new Properties()
        {
            MaxCharacterHealth = 125,
            Health = 150,
            Damage = 1.5f,
            WalkSpeed = 2,
            SprintSpeed = 3,
            CrouchSpeed = 1,
        };

        // Слабкий, але розумний
        public Properties PaniniProperty = new Properties()
        {
            MaxCharacterHealth = 75,
            Health = 75,
            Damage = 0.7f,
            WalkSpeed = 2,
            SprintSpeed = 3,
            CrouchSpeed = 1,
        };
        #endregion
    }

    // серіалізуємий клас, який представляє із себе дані гравця
    [System.Serializable]
    public class Properties
    {
        public float MaxCharacterHealth;
        public float Health;
        public float Damage;
        public float Armor;

        public float WalkSpeed;
        public float SprintSpeed;
        public float CrouchSpeed;
    }
}
