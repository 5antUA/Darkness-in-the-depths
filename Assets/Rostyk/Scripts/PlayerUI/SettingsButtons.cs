using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Obsolete]
public class SettingsButtons : MonoBehaviour
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button CreativeModeButton;
    [SerializeField] private Button SurvivalModeButton;
    [SerializeField] private GameObject InventoryUI;
    [SerializeField] private PlayerCanvas Canvas;

    [SerializeField] private Player MyPlayer;

    public void DoExit()
    {
        InventoryUI.active = false;
        Canvas.InventoryEnabled = false;
        Canvas.PlayerInfo.enabled = true;

        GetComponentInParent<RotateCamera>().enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void ApplyCreativeMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.creative;
    }

    public void ApplySurvivalMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.survival;
    }
}
