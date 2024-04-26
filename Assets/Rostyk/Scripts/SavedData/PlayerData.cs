using RostykEnums;
using System.Collections.Generic;
using UnityEngine;

namespace SavedData
{
    [System.Serializable]
    public class PlayerData
    {
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