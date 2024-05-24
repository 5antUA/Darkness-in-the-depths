using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SavedData
{
    [System.Serializable]
    public class ObjectFactoryData
    {
        private const string KEY = "ObjectFactoryData";

        public List<EnemyData> EnemiesList = new List<EnemyData>();

        public void Save(List<GameObject> Enemies)
        {
            foreach (var enemy in Enemies)
            {
                Vector3 pos = enemy.transform.position;
                Quaternion rot = enemy.transform.rotation;

                EnemiesList.Add(new EnemyData(pos, rot));
            }

            StorageService.Save(KEY, this);
        }

        public ObjectFactoryData Load(List<GameObject> Enemies)
        {
            try
            {
                var newData = StorageService.Load<ObjectFactoryData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save(Enemies);
                return this;
            }
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