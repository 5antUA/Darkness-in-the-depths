using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ — –»œ Õ¿ Œ¡⁄≈ “ PlayerUI
public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject InventoryUI;
    protected PlayerRotation PlayerCamera;
    protected Player MyPlayer;
    protected Text PlayerInfo;

    protected bool InventoryEnabled { get; set; }


    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        PlayerInfo = GetComponentInChildren<Text>();
        PlayerCamera = GetComponentInParent<PlayerRotation>();

        InventoryUI.SetActive(false);
        InventoryEnabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("pressed E");

        InventoryControl();
    }

    public void InventoryControl()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (InventoryEnabled == false)
            {
                OpenInventory();
            }
            else if (InventoryEnabled == true)
            {
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        InventoryEnabled = true;
        PlayerInfo.enabled = false;

        PlayerCamera.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

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
