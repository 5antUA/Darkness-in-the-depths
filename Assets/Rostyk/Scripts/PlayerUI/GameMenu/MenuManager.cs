using UnityEngine;
using UnityEngine.SceneManagement;


// ³���� �� ��'��� PlayerUI
public class MenuManager : MonoBehaviour
{
    public GameObject MenuUI;                                   // ���� ������� ��'��� MenuUI

    private Player Player;                                      // ������ Player
    private PlayerRotation PlayerCamera;                        // ������ PlayerRotation
    private SavedData.InputData _inputData;                     // ����� ��� ��� ������
    private SavedData.InterfaceData _interfaceData;             // ��� ��� ������� ���������


    private void Awake()
    {
        _inputData = new SavedData.InputData();
        _interfaceData = new SavedData.InterfaceData();
        _inputData = _inputData.Load();
        _interfaceData = _interfaceData.Load();
    }

    private void Start()
    {
        Player = this.GetComponentInParent<Player>();
        PlayerCamera = this.GetComponentInParent<PlayerRotation>();
        MenuUI.SetActive(false);
    }

    private void Update()
    {
        if (Player.IsDead)
            return;

        MenuControl();
    }


    // �������� ����
    public void MenuControl()
    {
        if (Input.GetKeyDown(_inputData.Inventory) && !MenuUI.activeInHierarchy)
        {
            OpenMenu();
        }
        else if (Input.GetKeyDown(_inputData.Inventory) && MenuUI.activeInHierarchy)
        {
            CloseMenu();
        }
    }

    // ������� ���� (������� �������� ������� ��'��� MenuUI)
    public void OpenMenu()
    {
        MenuUI.SetActive(true);
        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // ������� ���� (������� ���������� ������� ��'��� MenuUI)
    public void CloseMenu()
    {
        MenuUI.SetActive(false);
        PlayerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // ������ ���������� � ������� ����
    public void ToMainMenuButton()
    {
        SceneManager.LoadScene("Main menu");
    }
}
