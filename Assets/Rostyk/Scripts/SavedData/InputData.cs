using System.IO;
using UnityEngine;

namespace SavedData
{
    // Класс для хранения KeyCodes
    [System.Serializable]
    public class InputData
    {
        private const string KEY = "KeyInputData";

        public KeyCode CrouchButton;
        public KeyCode RunButton;
        public KeyCode JumpButton;
        public KeyCode InventoryButton;
        public KeyCode InfoButton;
        public KeyCode SwitchLightButton;

        public InputData()
        {
            CrouchButton = KeyCode.LeftShift;
            RunButton = KeyCode.LeftControl;
            JumpButton = KeyCode.Space;
            InventoryButton = KeyCode.Tab;
            InfoButton = KeyCode.Q;
            SwitchLightButton = KeyCode.F;
        }

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
    }
}
