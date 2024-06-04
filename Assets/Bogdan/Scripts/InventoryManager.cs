using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    private SavedData.InputData takeItem;
    public Transform inventoryPanel;
    public List<InventorySlot> slots = new List<InventorySlot>();
    private Camera mainCamera;
    public GameObject MenuUi;
    public float reachDistance = 3f;
    // Start is called before the first frame update
    void Start()
    {
        takeItem = new();
        takeItem = takeItem.Load();
        mainCamera = Camera.main;
        for (int i = 0; i < inventoryPanel.childCount; i++) 
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null) 
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayTake = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetKeyDown(takeItem.Interact) && !MenuUi.activeInHierarchy)
        {


            if (Physics.Raycast(rayTake, out hit, reachDistance))
            {
                Debug.Log("dsaasd");
                Debug.Log(hit.collider);
                if (hit.collider.gameObject.GetComponent<Item>() != null)
                {
                    Debug.Log(hit.collider.gameObject.GetComponent<Item>());
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item);
                    Destroy(hit.collider.gameObject);
                    Debug.DrawLine(rayTake.origin, hit.point, Color.red);
                }

            }
        }
        
    }
    private void AddItem(ItemScriptableObject _item)
    {

        foreach (InventorySlot slot in slots)
        {
            if(slot.isEmpty == true)
            {
                slot.item = _item;
                slot.isEmpty = false;
                slot.SetIcon(_item.icon);
                break;
            }
        }
    }
}
