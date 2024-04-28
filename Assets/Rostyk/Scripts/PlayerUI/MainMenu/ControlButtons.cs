using SavedData;
using System;
using System.Collections;
using UnityEngine;


// ������ �� TabsUI/ControlUI
public class ControlButtons : MonoBehaviour
{
    // STORAGE SERVICES
    InputData InputData;

    // OTHER
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));      // ����� ���� KeyCode
    private delegate void LocalFunction();                                  // ����� �������
    private KeyCode currentKey;                                             // ��������� ������

    private void Start()
    {
        InputData = new InputData();
        InputData = InputData.Load();
    }


    #region Buttons
    // ����� ������ ��� ���������� (����� ������� ������)
    public void ChangeCrouchButton()
    {
        void _func()
        {
            InputData.Run = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ���� (����� ������� ������)
    public void ChangeRunButton()
    {
        void _func()
        {
            InputData.Run = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ������� (����� ������� ������)
    public void ChangeJumpButton()
    {
        void _func()
        {
            InputData.Jump = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� �������� ��������� (����� ������� ������)
    public void ChangeInventoryButton()
    {
        void _func()
        {
            InputData.Inventory = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ������� UI (����� ������� ������)
    public void ChangeInfoButton()
    {
        void _func()
        {
            InputData.Info = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� �������� (����� ������� ������)
    public void ChangeSwitchButton()
    {
        void _func()
        {
            InputData.SwitchLight = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� �������� (����� ������� ������)
    public void ChangeShootButton()
    {
        void _func()
        {
            InputData.Shoot = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ �������������� (����� ������� ������)
    public void ChangeInteractButton()
    {
        void _func()
        {
            InputData.Interact = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ InputData (����� ������� ������)
    public void ToDefaultSettingsButton()
    {
        InputData = new InputData();
        InputData.Save();
    }
    #endregion


    // ��������. ��������, ���� �� �������� ������ � ���� �������� ����������
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
