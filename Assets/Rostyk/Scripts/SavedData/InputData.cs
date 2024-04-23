using UnityEngine;

namespace SavedData
{
    [System.Serializable]
    public class InputData
    {
        public const string KEY_InputData = "KeyInputData";

        KeyCode CrouchButton;
        KeyCode RunButton;
        KeyCode JumpButton;
        KeyCode InventoryButton;
        KeyCode InfoButton;
        KeyCode FlashlightButton;

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