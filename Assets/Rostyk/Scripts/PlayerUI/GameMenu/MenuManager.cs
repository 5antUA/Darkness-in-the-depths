using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class MenuManager : MonoBehaviour
{
    private SavedData.InputData InputData;

    public GameObject MenuUI;                                   // MenuUI
    private PlayerRotation PlayerCamera;                        // скрипт this.PlayerRotation
    private Text PlayerInfo;                                    // информация об игроке (Text UI)

    private bool MenuEnabled { get; set; }                      // свойство, показывающее открыто ли меню

    private void Awake()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();
    }
    private void Start()
    {
        PlayerCamera = GetComponentInParent<PlayerRotation>();
        PlayerInfo = GetComponentInChildren<Text>();

        MenuUI.SetActive(false);
        MenuEnabled = false;
    }

    private void Update()
    {
        MenuControl();
    }


    // Контроль меню
    public void MenuControl()
    {
        if (Input.GetKeyDown(InputData.InventoryButton) && MenuEnabled == false)
        {
            OpenMenu();
        }
        else if ((Input.GetKeyDown(InputData.InventoryButton) || Input.GetKeyDown(KeyCode.Escape)) && MenuEnabled == true)
        {
            CloseMenu();
        }
    }

    // Открыть меню
    public void OpenMenu()
    {
        MenuUI.SetActive(true);
        MenuEnabled = true;
        PlayerInfo.enabled = false;

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Закрыть меню
    public void CloseMenu()
    {
        MenuUI.SetActive(false);
        MenuEnabled = false;
        PlayerInfo.enabled = true;

        PlayerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
