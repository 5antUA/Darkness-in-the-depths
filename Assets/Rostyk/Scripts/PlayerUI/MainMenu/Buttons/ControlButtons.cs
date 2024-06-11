using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// Вішати на об'єкт TabsUI/ControlUI
public class ControlButtons : MonoBehaviour
{
    [SerializeField] private Text[] buttons;                                  // масив всіх кнопок

    protected readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));      // масив всіх KeyCode
    protected delegate void LocalFunction();                                  // загальний делегат
    protected KeyCode currentKey;                                             // шаблонна кнопка
    protected SavedData.InputData InputData;                                  // ігрові дані про клавіші


    private void Start()
    {
        InputData = new();
        InputData = InputData.Load();

        InitButtonsInfo();
    }


    #region Buttons
    // кнопка для зміни клавіші присідання
    public void ChangeCrouch()
    {
        void _func()
        {
            InputData.Crouch = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші бігу
    public void ChangeRun()
    {
        void _func()
        {
            InputData.Run = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші стрибків
    public void ChangeJump()
    {
        void _func()
        {
            InputData.Jump = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші інвентаря
    public void ChangeInventory()
    {
        void _func()
        {
            InputData.Inventory = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші фонарика
    public void ChangeSwitch()
    {
        void _func()
        {
            InputData.SwitchLight = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші стрільби
    public void ChangeShoot()
    {
        void _func()
        {
            InputData.Shoot = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші взаємодії
    public void ChangeInteract()
    {
        void _func()
        {
            InputData.Interact = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші перезарядки
    public void ChangeReload()
    {
        void _func()
        {
            InputData.Reload = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші збереження гри
    public void ChangeSaveGame()
    {
        void _func()
        {
            InputData.SaveGame = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для зміни клавіші завантаження гри
    public void ChangeLoadGame()
    {
        void _func()
        {
            InputData.LoadGame = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // кнопка для скидування налаштувань
    public void ResetSettings()
    {

        InputData = new();
        InputData.Save();

        InitButtonsInfo();
    }
    #endregion


    #region Services
    // асинхронна функція для зміни клавіші
    protected IEnumerator ReadInput(LocalFunction function)
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
                        InitButtonsInfo();

                        yield break;
                    }
                }
            }
        }
    }

    // ініціалізація текстів кнопок
    private void InitButtonsInfo()
    {
        buttons[0].text = InputData.Crouch.ToString();
        buttons[1].text = InputData.Run.ToString();
        buttons[2].text = InputData.Jump.ToString();
        buttons[3].text = InputData.Inventory.ToString();
        buttons[4].text = InputData.SwitchLight.ToString();
        buttons[5].text = InputData.Shoot.ToString();
        buttons[6].text = InputData.Interact.ToString();
        buttons[7].text = InputData.Reload.ToString();
        buttons[8].text = InputData.SaveGame.ToString();
        buttons[9].text = InputData.LoadGame.ToString();
    }
    #endregion
}
