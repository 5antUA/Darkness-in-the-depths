using System.IO;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения transform игрока
    [System.Serializable]
    public class PlayerPositionData
    {
        private const string KEY = "PlayerPositionData";

        public Vector3 position;
        public Quaternion rotation;

        public PlayerPositionData(Vector3 DefaultPos = new())
        {
            position = DefaultPos;
            rotation = Quaternion.identity;
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public PlayerPositionData Load()
        {
            try
            {
                var newData = StorageService.Load<PlayerPositionData>(KEY);
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