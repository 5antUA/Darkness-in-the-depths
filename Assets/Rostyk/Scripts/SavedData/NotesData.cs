using System;
using System.IO;
using System.Numerics;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения Notes
    [System.Serializable]
    public class NotesData
    {
        private const string KEY = "NotesData";

        public bool[] isActivated = new bool[8];

        public NotesData()
        {
            isActivated = new bool[8];
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public NotesData Load()
        {
            try
            {
                var data = StorageService.Load<NotesData>(KEY);
                return data;
            }
            catch (FileNotFoundException)
            {
                Save();
                return this;
            }
        }
        #endregion


        #region Notes
        public readonly string[] Notes =
{
            "Я думаю якшо буде мало часу то нам вдвох прийдеться йому помагати",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"
        };
        #endregion
    }
}

