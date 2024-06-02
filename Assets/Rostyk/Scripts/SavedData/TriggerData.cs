using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SavedData
{
    [System.Serializable]
    public class TriggerData
    {
        private const string KEY = "TriggerData";

        public bool[] IsDestroyedObject;

        public TriggerData(List<GameObject> TriggerList)
        {
            IsDestroyedObject = new bool[TriggerList.Count];
        }


        #region Management
        public void Save(List<GameObject> Enemies)
        {
            StorageService.Save(KEY, this);
        }

        public TriggerData Load(List<GameObject> TriggerList)
        {
            try
            {
                var newData = StorageService.Load<TriggerData>(KEY);
                return newData;
            }
            catch (FileNotFoundException)
            {
                Save(TriggerList);
                return this;
            }
        }
        #endregion
    }
}