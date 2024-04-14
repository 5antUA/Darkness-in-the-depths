using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ Buttons
public class SettingsButtons : InventoryManager
{
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button CreativeModeButton;
    [SerializeField] private Button SurvivalModeButton;


    // Функция для выхода из инвентаря по нажатию кнопки
    public void DoExit()
    {
        OpenInventory();
    }

    // Функция для активации режима креатива по нажатию кнопки
    public void ApplyCreativeMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.creative;
    }

    // Функция для активации режима выживания по нажатию кнопки
    public void ApplySurvivalMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.survival;
    }
}
