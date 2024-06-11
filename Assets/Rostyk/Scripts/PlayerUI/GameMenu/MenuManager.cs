using UnityEngine;
using UnityEngine.SceneManagement;


// Вішати на об'єкт PlayerUI
public class MenuManager : MonoBehaviour
{
    public GameObject MenuUI;                                   // весь ігровий об'єкт MenuUI

    private Player Player;                                      // скрипт Player
    private PlayerRotation PlayerCamera;                        // скрипт PlayerRotation
    private SavedData.InputData _inputData;                     // ігрові дані про клавіші
    private SavedData.InterfaceData _interfaceData;             // дані про ігровий інтерфейс


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


    // Контроль меню
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

    // відкрити меню (зробити активним ігровий об'єкт MenuUI)
    public void OpenMenu()
    {
        MenuUI.SetActive(true);
        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // закрити меню (зробити неактивним ігровий об'єкт MenuUI)
    public void CloseMenu()
    {
        MenuUI.SetActive(false);
        PlayerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // кнопка повернення в головне меню
    public void ToMainMenuButton()
    {
        SceneManager.LoadScene("Main menu");
    }
}
