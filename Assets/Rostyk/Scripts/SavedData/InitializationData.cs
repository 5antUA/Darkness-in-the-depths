using RostykEnums;
using System.IO;
using UnityEngine;


namespace SavedData
{
    [System.Serializable]
    public class InitializationData
    {
        private const string KEY = "InitializationData";

        public bool isContinueGame;
        public Characters Character;
        public PlayingCharacter CurrentCharacter;


        public InitializationData()
        {
            isContinueGame = false;
            CurrentCharacter = null;
        }

        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public InitializationData Load()
        {
            try
            {
                var newData = StorageService.Load<InitializationData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }

        public Character GetCharacterProperties()
        {
            return new Character();
        }

        #region Characters
        // Слабый, но быстрый
        public readonly PlayingCharacter RadchenkoChar = new PlayingCharacter()
        {
            MaxCharacterHealth = 75,
            Health = 75,
            Damage = 0.7f,
            WalkSpeed = 5,
            SprintSpeed = 7,
            CrouchSpeed = 4

        };

        // Золотая средина
        public readonly PlayingCharacter KovalevChar = new PlayingCharacter()
        {
            MaxCharacterHealth = 100,
            Health = 100,
            Damage = 1,
            WalkSpeed = 4,
            SprintSpeed = 5,
            CrouchSpeed = 3
        };

        // Сильный, но медленный
        public readonly PlayingCharacter ValentinChar = new PlayingCharacter()
        {
            MaxCharacterHealth = 150,
            Health = 150,
            Damage = 1.5f,
            WalkSpeed = 3,
            SprintSpeed = 4,
            CrouchSpeed = 2
        };
        #endregion

        [System.Serializable]
        public class PlayingCharacter
        {
            [Header("\t CHARACTER PROPERTIES")]
            [Space]

            public float MaxCharacterHealth;  
            public float Health;
            public float Damage;
            public float Armor;

            public float WalkSpeed;
            public float SprintSpeed;
            public float CrouchSpeed;
        }
    }
}
