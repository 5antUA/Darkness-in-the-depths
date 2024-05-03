﻿using System.IO;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения KeyCodes
    [System.Serializable]
    public class InputData
    {
        private const string KEY = "InputData";

        public KeyCode Crouch;              // клавиша приседания
        public KeyCode Run;                 // клавиша бега
        public KeyCode Jump;                // клавиша прыжка
        public KeyCode Inventory;           // клавиша инвентаря
        public KeyCode Info;                // клавиша UI
        public KeyCode SwitchLight;         // клавиша фонарика
        public KeyCode Shoot;               // клавиша стрельбы
        public KeyCode Interact;            // клавиша взаимодействия
        public KeyCode Reload;              // клавиша перезарядки

        public InputData()
        {
            Crouch = KeyCode.LeftShift;
            Run = KeyCode.LeftControl;
            Jump = KeyCode.Space;
            Inventory = KeyCode.Tab;
            Info = KeyCode.Q;
            SwitchLight = KeyCode.F;
            Shoot = KeyCode.Mouse0;
            Interact = KeyCode.Mouse1;
            Reload = KeyCode.R;
        }


        #region Management
        public void Save()
        {
            StorageService.Save(KEY, this);
        }

        public InputData Load()
        {
            try
            {
                var data = StorageService.Load<InputData>(KEY);
                return data;
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
