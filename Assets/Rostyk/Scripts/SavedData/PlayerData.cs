using RostykEnums;
using UnityEngine;

namespace SavedData
{
    [System.Serializable]
    public class PlayerData
    {
        public int Health;
        public int Armor;
        public Gamemode Gamemode;
        public Transform playerTransform;
    }
}