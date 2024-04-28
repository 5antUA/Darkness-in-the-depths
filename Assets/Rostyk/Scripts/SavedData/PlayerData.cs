using RostykEnums;
using System.IO;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения данных об игроке
    [System.Serializable]
    public class PlayerData
    {
        private const string KEY = "PlayerData";

        public float Health;
        public float Armor;
        public Gamemode Gamemode;
        public Vector3 position;
        public Quaternion rotation;

        public PlayerData()
        {
            Health = 100;
            Armor = 0;
            Gamemode = Gamemode.survival;
            position = new Vector3();
            rotation = Quaternion.identity;
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public PlayerData Load()
        {
            try
            {
                var newData = StorageService.Load<PlayerData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }
        #endregion
    }
}