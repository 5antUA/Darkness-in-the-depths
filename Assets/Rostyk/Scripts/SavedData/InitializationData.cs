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
        public Characters PlayingCharacter;
        public Charactersd CurrentCharacter;


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


        #region Characters
        // Слабый, но быстрый
        private Charactersd RadchenkoChar = new Charactersd()
        {
            MaxCharacterHealth = 75,
            Health = 75,
            Damage = 0.7f,
            WalkSpeed = 5,
            SprintSpeed = 7,
            CrouchSpeed = 4

        };

        // Золотая средина
        private Charactersd KovalevChar = new Charactersd()
        {
            MaxCharacterHealth = 100,
            Health = 100,
            Damage = 1,
            WalkSpeed = 4,
            SprintSpeed = 5,
            CrouchSpeed = 3
        };

        // Сильный, но медленный
        private Charactersd ValentinChar = new Charactersd()
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
        public class Charactersd
        {
            [Header("\t CHARACTER PROPERTIES")]
            [Space]

            [HideInInspector]
            public float MaxCharacterHealth;                           // максимальное количество здоровья персонажа  
            public float Health;                                       // количество здоровья
            public float Damage;                                       // количество урона
            public float Armor;                                        // количество брони

            public float WalkSpeed;                                    // скорость ходьбы
            public float SprintSpeed;                                  // скорость бега
            public float CrouchSpeed;                                  // скорость медленной ходьбы


            public bool IsDead => Health <= 0;                         // если умер


            // Функция для получения урона
            public void TakeDamage(float damage)
            {
                this.Health -= damage;
            }
        }
    }
}
