using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ������ ����� �� ������ PlayerUI
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;            // inventoryUI (player object)
    private PlayerRotation PlayerCamera;                        // ������ this.PlayerRotation
    private Text PlayerInfo;                                    // ���������� �� ������ (Text UI)

    private bool InventoryEnabled { get; set; }                 // ��������, ������������ ������ �� ���������


    private void Start()
    {
        PlayerCamera = GetComponentInParent<PlayerRotation>();
        PlayerInfo = GetComponentInChildren<Text>();

        InventoryUI.SetActive(false);
        InventoryEnabled = false;
    }

    // �������� ���������
    public void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && InventoryEnabled == false)
        {
            OpenInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && InventoryEnabled == true)
        {
            CloseInventory();
        }
    }

    // ������� ���������
    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        InventoryEnabled = true;
        PlayerInfo.enabled = false;

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // ������� ���������
    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        InventoryEnabled = false;
        PlayerInfo.enabled = true;

        PlayerCamera.enabled = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
