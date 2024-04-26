using UnityEngine;

namespace SavedData
{
    // Класс для хранения KeyCodes
    [System.Serializable]
    public class InputData
    {
        public const string KEY = "KeyInputData";

        public KeyCode CrouchButton;
        public KeyCode RunButton;
        public KeyCode JumpButton;
        public KeyCode InventoryButton;
        public KeyCode InfoButton;
        public KeyCode FlashlightButton;

        public InputData()
        {
            CrouchButton = KeyCode.LeftShift;
            RunButton = KeyCode.LeftControl;
            JumpButton = KeyCode.Space;
            InventoryButton = KeyCode.Tab;
            InfoButton = KeyCode.Q;
            FlashlightButton = KeyCode.F;
        }
    }
}
