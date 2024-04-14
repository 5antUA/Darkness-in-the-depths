using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ Buttons
public class SettingsButtons : MonoBehaviour
{
    [SerializeField] private Player MyPlayer;                   // скрипт this.PlayerRotation
    [SerializeField] private Button ExitButton;                 // кнопка выхода
    [SerializeField] private Button CreativeModeButton;         // кнопка перехода в CreativeMode
    [SerializeField] private Button SurvivalModeButton;         // кнопка перехода в SurvivalMode


    // Функция для выхода из инвентаря по нажатию кнопки
    public void Exit()
    {
        GetComponentInParent<InventoryManager>().CloseInventory();
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
