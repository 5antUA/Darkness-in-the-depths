using System.IO;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения данных об игроке
    [System.Serializable]
    public class PlayerData
    {
        private const string KEY = "PlayerData";

        public Vector3 position;
        public Quaternion rotation;

        public PlayerData(Vector3 DefaultPos = new())
        {
            position = DefaultPos;
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