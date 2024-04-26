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
        public Vector3 playerTransform;
    }
}