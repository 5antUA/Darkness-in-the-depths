using SavedData;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


// ������ �� TabsUI/ControlUI
public class ControlButtons : MonoBehaviour
{
    // STORAGE SERVICES
    protected InputData InputData;

    // OTHER
    [SerializeField] private Text[] buttons;
    protected readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));      // ����� ���� KeyCode
    protected delegate void LocalFunction();                                  // ����� �������
    protected KeyCode currentKey;                                             // ��������� ������

    private void Start()
    {
        InputData = new InputData();
        InputData = InputData.Load();

        InitButtonsInfo();
    }


    #region Buttons
    // ����� ������ ��� ���������� (����� ������� ������)
    public void ChangeCrouch()
    {
        void _func()
        {
            InputData.Crouch = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ���� (����� ������� ������)
    public void ChangeRun()
    {
        void _func()
        {
            InputData.Run = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ������� (����� ������� ������)
    public void ChangeJump()
    {
        void _func()
        {
            InputData.Jump = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� �������� ��������� (����� ������� ������)
    public void ChangeInventory()
    {
        void _func()
        {
            InputData.Inventory = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ������� UI (����� ������� ������)
    public void ChangeInfo()
    {
        void _func()
        {
            InputData.Info = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� �������� (����� ������� ������)
    public void ChangeSwitch()
    {
        void _func()
        {
            InputData.SwitchLight = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� �������� (����� ������� ������)
    public void ChangeShoot()
    {
        void _func()
        {
            InputData.Shoot = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ �������������� (����� ������� ������)
    public void ChangeInteract()
    {
        void _func()
        {
            InputData.Interact = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ ��� ������� UI (����� ������� ������)
    public void ChangeReload()
    {
        void _func()
        {
            InputData.Reload = currentKey;
            InputData.Save();
        }

        StartCoroutine(ReadInput(_func));
    }

    // ����� ������ InputData (����� ������� ������)
    public void ResetSettings()
    {
        InputData = new InputData();
        InputData.Save();

        InitButtonsInfo();
    }
    #endregion


    #region Services
    // ��������. ��������, ���� �� �������� ������ � ���� �������� ����������
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

    private void InitButtonsInfo()
    {
        buttons[0].text = InputData.Crouch.ToString();
        buttons[1].text = InputData.Run.ToString();
        buttons[2].text = InputData.Jump.ToString();
        buttons[3].text = InputData.Inventory.ToString();
        buttons[4].text = InputData.Info.ToString();
        buttons[5].text = InputData.SwitchLight.ToString();
        buttons[6].text = InputData.Shoot.ToString();
        buttons[7].text = InputData.Interact.ToString();
        buttons[8].text = InputData.Reload.ToString();
    }
    #endregion
}
