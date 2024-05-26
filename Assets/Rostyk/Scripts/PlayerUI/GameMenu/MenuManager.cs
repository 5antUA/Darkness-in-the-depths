using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class MenuManager : MonoBehaviour
{
    private SavedData.InputData InputData;
    private SavedData.InterfaceData InterfaceData;

    public GameObject MenuUI;                                   // Menu UI
    public GameObject DeathMenu;
    public GameObject HealthBar;                                // HealthBar UI
    private Player Player;
    private PlayerRotation PlayerCamera;                        // скрипт this.PlayerRotation


    private void Awake()
    {
        InputData = new SavedData.InputData();
        InterfaceData = new SavedData.InterfaceData();

        InputData = InputData.Load();
        InterfaceData = InterfaceData.Load();
    }

    private void Start()
    {
        Player = GetComponentInParent<Player>();
        PlayerCamera = GetComponentInParent<PlayerRotation>();

        MenuUI.SetActive(false);
    }

    private void Update()
    {
        MenuControl();
    }


    // Контроль меню
    public void MenuControl()
    {
        if (Input.GetKeyDown(InputData.Inventory) && !MenuUI.activeInHierarchy)
        {
            OpenMenu();
        }
        else if (Input.GetKeyDown(InputData.Inventory) && MenuUI.activeInHierarchy)
        {
            CloseMenu();
        }
    }

    // Открыть меню
    public void OpenMenu()
    {
        MenuUI.SetActive(true);
        HealthBar.SetActive(false);

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Закрыть меню
    public void CloseMenu()
    {
        MenuUI.SetActive(false);
        HealthBar.SetActive(true);

        PlayerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void ToMainMenuButton()
    {
        SceneManager.LoadScene("Main menu");
    }
}
