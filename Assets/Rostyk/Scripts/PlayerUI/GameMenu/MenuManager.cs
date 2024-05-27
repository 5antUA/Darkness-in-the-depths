using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class MenuManager : MonoBehaviour
{
    private SavedData.InputData InputData;
    private SavedData.InterfaceData InterfaceData;

    [Space]
    [Header("\t Our properties")]
    public GameObject MenuUI;                                   // Menu UI
    public GameObject HealthBar;                                // HealthBar UI
    private PlayerRotation PlayerCamera;                        // скрипт this.PlayerRotation
    private Player Player;

    [Space]
    [Header("\t DeathScreen")]
    [SerializeField] private Image BlackImage;
    [SerializeField] private Image Background;
    [SerializeField] private Image YouDeadImage;

    private void Awake()
    {
        InputData = new SavedData.InputData();
        InterfaceData = new SavedData.InterfaceData();

        InputData = InputData.Load();
        InterfaceData = InterfaceData.Load();
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

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Закрыть меню
    public void CloseMenu()
    {
        MenuUI.SetActive(false);

        PlayerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void ToMainMenuButton()
    {
        SceneManager.LoadScene("Main menu");
    }
}
