using SavedData;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ Õ¿ SettingsTab/Buttons
public class SettingsControlButtons : MonoBehaviour
{
    // STORAGE SERVICES
    SavedData.InputData InputData;

    // OTHER
    [SerializeField] private Text text;
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    private void Start()
    {
        InputData = new InputData();
        InputData = InputData.Load();
    }

    public void ChangeKey()
    {
        StartCoroutine(ReadInput(text));
    }

    private IEnumerator ReadInput(Text buttonText)
    {
        while (true)
        {
            yield return null;

            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in keyCodes)
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        buttonText.text = keyCode.ToString();
                        InputData.SwitchLightButton = keyCode;
                        InputData.Save();
                        yield break;
                    }
                }
            }
        }
    }
}
