using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ������ ������ �� ������ TabDevUI/Buttons
public class TabDevButtons : MonoBehaviour
{
    [SerializeField] private Player MyPlayer;                   // ������ this.Player


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

    // ������� ��� ��������� ������ ������� (����� ������� ������)
    public void ApplyHardcoreMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.hardcore;
    }

    // ������� ��� ��������� ������ �������� (����� ������� ������)
    public void ApplyInfetnumMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.infernum;
    }
}
