using RostykEnums;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения данных об игроке
    [System.Serializable]
    public class PlayerData
    {
        private const string KEY = "PlayerPropertiesData";

        public int Health;
        public int Armor;
        public Gamemode Gamemode;
        public Vector3 playerPosition;

        public PlayerData()
        {
            Health = 100;
            Armor = 0;
            Gamemode = Gamemode.survival;
            playerPosition = new Vector3(-42, 1, 125);
        }
    }
}