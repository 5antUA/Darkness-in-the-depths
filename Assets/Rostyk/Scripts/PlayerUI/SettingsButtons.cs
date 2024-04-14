using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// ������ ������ �� ������ Buttons
public class SettingsButtons : InventoryManager
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button CreativeModeButton;
    [SerializeField] private Button SurvivalModeButton;


    // ������� ��� ������ �� ��������� �� ������� ������
    public void DoExit()
    {
        OpenInventory();
    }

    // ������� ��� ��������� ������ �������� �� ������� ������
    public void ApplyCreativeMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.creative;
    }

    // ������� ��� ��������� ������ ��������� �� ������� ������
    public void ApplySurvivalMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.survival;
    }
}
