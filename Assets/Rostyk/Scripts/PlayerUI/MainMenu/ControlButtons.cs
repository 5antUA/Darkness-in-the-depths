using SavedData;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ Õ¿ TabsUI/ControlUI
public class ControlButtons : MonoBehaviour
{
    // STORAGE SERVICES
    InputData InputData;

    // OTHER
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));
    private delegate void LocalFunction();
    private KeyCode currentKey;

    private void Start()
    {
        InputData = new InputData();
        InputData = InputData.Load();
    }

    // 
    public void ChangeCrouchButton()
    {
        void _func()
        {
            InputData.RunButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // 
    public void ChangeRunButton()
    {
        void _func()
        {
            InputData.RunButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // 
    public void ChangeJumpButton()
    {
        void _func()
        {
            InputData.JumpButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // 
    public void ChangeInventoryButton()
    {
        void _func()
        {
            InputData.InventoryButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // 
    public void ChangeInfoButton()
    {
        void _func()
        {
            InputData.InfoButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // 
    public void ChangeSwitchButton()
    {
        void _func()
        {
            InputData.SwitchLightButton = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    //
    public void ToDefaultSettingsButton()
    {
        InputData = new InputData();
        InputData.Save();
    }

    // 
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
