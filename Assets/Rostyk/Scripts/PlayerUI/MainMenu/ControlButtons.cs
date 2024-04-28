using SavedData;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ НА TabsUI/ControlUI
public class ControlButtons : MonoBehaviour
{
    // STORAGE SERVICES
    InputData InputData;

    // OTHER
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));      // Масив всех KeyCode
    private delegate void LocalFunction();                                  // общий делегат
    private KeyCode currentKey;                                             // шаблонная кнопка

    private void Start()
    {
        InputData = new InputData();
        InputData = InputData.Load();
    }


    // Смена кнопки для приседания (метод нажатия кнопки)
    public void ChangeCrouchButton()
    {
        void _func()
        {
            InputData.RunButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для бега (метод нажатия кнопки)
    public void ChangeRunButton()
    {
        void _func()
        {
            InputData.RunButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для прыжков (метод нажатия кнопки)
    public void ChangeJumpButton()
    {
        void _func()
        {
            InputData.JumpButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для открытия инвентаря (метод нажатия кнопки)
    public void ChangeInventoryButton()
    {
        void _func()
        {
            InputData.InventoryButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для скрытия UI (метод нажатия кнопки)
    public void ChangeInfoButton()
    {
        void _func()
        {
            InputData.InfoButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для фонарика (метод нажатия кнопки)
    public void ChangeSwitchButton()
    {
        void _func()
        {
            InputData.SwitchLightButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Сброс данных InputData (метод нажатия кнопки)
    public void ToDefaultSettingsButton()
    {
        InputData = new InputData();
        InputData.Save();
    }


    // Корутина. Работает, пока не нажмется кнопка в меню настроек управления
    private IEnumerator ReadInput(LocalFunction function)
    {
        while (true)
        {
            yield return null;

            if (Input.anyKeyDown)
            {
                foreach (KeyCode newKey in keyCodes)
                {
                    if (Input.GetKeyDown(newKey))
                    {
                        currentKey = newKey;
                        function();
                        yield break;
                    }
                }
            }
        }
    }
}
