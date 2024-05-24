using RostykEnums;
using System.IO;


namespace SavedData
{
    // Класс для хранения характеристик игрока
    [System.Serializable]
    public class CharacterData
    {
        private const string KEY = "CharacterData";

        public bool isContinueGame;
        public Characters Character;
        public Properties Property;

        public CharacterData()
        {
            isContinueGame = false;
            Property = null;
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

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
        #endregion


        #region Characters
        // Слабый, но быстрый
        public Properties RadchenkoProperty = new Properties()
        {
            MaxCharacterHealth = 75,
            Health = 75,
            Damage = 0.7f,
            WalkSpeed = 5,
            SprintSpeed = 7,
            CrouchSpeed = 4

        };

        // Золотая средина
        public Properties KovalevProperty = new Properties()
        {
            MaxCharacterHealth = 100,
            Health = 100,
            Damage = 1,
            WalkSpeed = 4,
            SprintSpeed = 5,
            CrouchSpeed = 3
        };

        // Сильный, но медленный
        public Properties ValentinProperty = new Properties()
        {
            MaxCharacterHealth = 150,
            Health = 150,
            Damage = 1.5f,
            WalkSpeed = 3,
            SprintSpeed = 4,
            CrouchSpeed = 2
        };
        #endregion
    }

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
