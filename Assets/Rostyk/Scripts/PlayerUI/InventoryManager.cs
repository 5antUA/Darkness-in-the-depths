using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;            // inventoryUI (player object)
    private PlayerRotation PlayerCamera;                        // скрипт this.PlayerRotation
    private Text PlayerInfo;                                    // информация об игроке (Text UI)

    private bool InventoryEnabled { get; set; }                 // свойство, показывающее открыт ли инвентарь


    private void Start()
    {
        PlayerCamera = GetComponentInParent<PlayerRotation>();
        PlayerInfo = GetComponentInChildren<Text>();

        InventoryUI.SetActive(false);
        InventoryEnabled = false;
    }

    // Контроль инвентаря
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

    // Открыть инвентарь
    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        InventoryEnabled = true;
        PlayerInfo.enabled = false;

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    // Закрыть инвентарь
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
