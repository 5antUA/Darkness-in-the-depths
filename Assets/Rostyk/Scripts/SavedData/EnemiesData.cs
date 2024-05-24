using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SavedData
{
    [System.Serializable]
    public class EnemiesData
    {
        public List<EnemyData> EnemiesList = new List<EnemyData>();

        public void Save(List<GameObject> Enemies)
        {
            foreach (var enemy in Enemies)
            {

            }
        }

        public void Load()
        {

        }
    }

    [System.Serializable]
    public class EnemyData
    {
        public Vector3 position;
        public Quaternion rotation;

        public EnemyData(Vector3 pos, Quaternion rot)
        {
            position = pos;
            rotation = rot;
        }
    }
}