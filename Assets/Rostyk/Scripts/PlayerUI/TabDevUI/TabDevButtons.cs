using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ TabDevUI/Buttons
public class TabDevButtons : MonoBehaviour
{
    [SerializeField] private Player MyPlayer;                   // скрипт this.Player


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

    // Функция для активации режима хардкор (метод нажатия кнопки)
    public void ApplyHardcoreMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.hardcore;
    }

    // Функция для активации режима инфернум (метод нажатия кнопки)
    public void ApplyInfetnumMode()
    {
        MyPlayer.GameMode = RostykEnums.Gamemode.infernum;
    }
}
