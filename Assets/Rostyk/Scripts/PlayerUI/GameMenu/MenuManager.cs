using UnityEngine;
using UnityEngine.UI;


// ������ ����� �� ������ PlayerUI
public class MenuManager : MonoBehaviour
{
    public GameObject MenuUI;                                   // MenuUI
    private PlayerRotation PlayerCamera;                        // ������ this.PlayerRotation
    private Text PlayerInfo;                                    // ���������� �� ������ (Text UI)

    private bool MenuEnabled { get; set; }                      // ��������, ������������ ������� �� ����


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


    // �������� ����
    public void MenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && MenuEnabled == false)
        {
            OpenMenu();
        }
        else if ((Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape)) && MenuEnabled == true)
        {
            CloseMenu();
        }
    }

    // ������� ����
    public void OpenMenu()
    {
        MenuUI.SetActive(true);
        MenuEnabled = true;
        PlayerInfo.enabled = false;

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // ������� ����
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
