using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ Buttons
public class TabDevButtons : MonoBehaviour
{
    [SerializeField] private Player MyPlayer;                   // скрипт this.PlayerRotation
    [SerializeField] private Button ExitButton;                 // кнопка выхода
    [SerializeField] private Button CreativeModeButton;         // кнопка перехода в CreativeMode
    [SerializeField] private Button SurvivalModeButton;         // кнопка перехода в SurvivalMode


    // Функция для выхода из инвентаря (метод нажатия кнопки)
    public void Exit()
    {
        GetComponentInParent<InventoryManager>().CloseInventory();
    }

    // Функция для активации режима креатива (метод нажатия кнопки)
    public void ApplyCreativeMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.creative;
    }

    // Функция для активации режима выживания (метод нажатия кнопки)
    public void ApplySurvivalMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.survival;
    }
}
