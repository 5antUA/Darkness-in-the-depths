using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ������ ������ �� ������ Buttons
public class TabDevButtons : MonoBehaviour
{
    [SerializeField] private Player MyPlayer;                   // ������ this.PlayerRotation
    [SerializeField] private Button ExitButton;                 // ������ ������
    [SerializeField] private Button CreativeModeButton;         // ������ �������� � CreativeMode
    [SerializeField] private Button SurvivalModeButton;         // ������ �������� � SurvivalMode


    // ������� ��� ������ �� ��������� (����� ������� ������)
    public void Exit()
    {
        GetComponentInParent<InventoryManager>().CloseInventory();
    }

    // ������� ��� ��������� ������ �������� (����� ������� ������)
    public void ApplyCreativeMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.creative;
    }

    // ������� ��� ��������� ������ ��������� (����� ������� ������)
    public void ApplySurvivalMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.survival;
    }
}
