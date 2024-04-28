using SavedData;
using System;
using System.Collections;
using UnityEngine;


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


    #region Buttons
    // Смена кнопки для приседания (метод нажатия кнопки)
    public void ChangeCrouchButton()
    {
        void _func()
        {
            InputData.Run = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для бега (метод нажатия кнопки)
    public void ChangeRunButton()
    {
        void _func()
        {
            InputData.Run = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для прыжков (метод нажатия кнопки)
    public void ChangeJumpButton()
    {
        void _func()
        {
            InputData.Jump = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для открытия инвентаря (метод нажатия кнопки)
    public void ChangeInventoryButton()
    {
        void _func()
        {
            InputData.Inventory = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для скрытия UI (метод нажатия кнопки)
    public void ChangeInfoButton()
    {
        void _func()
        {
            InputData.Info = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для фонарика (метод нажатия кнопки)
    public void ChangeSwitchButton()
    {
        void _func()
        {
            InputData.SwitchLight = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки для стрельбы (метод нажатия кнопки)
    public void ChangeShootButton()
    {
        void _func()
        {
            InputData.Shoot = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // Смена кнопки взаимодействия (метод нажатия кнопки)
    public void ChangeInteractButton()
    {
        void _func()
        {
            InputData.Interact = currentKey;
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
    #endregion


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
