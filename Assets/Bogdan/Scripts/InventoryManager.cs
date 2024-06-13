using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class InventoryManager : MonoBehaviour
{
    private SavedData.InputData InputData; //поле для отримання клавіши взаємодії
    private string[] id = new string[12]; //масив для збереження id предметів
    public Transform inventoryPanel; //батьківський об'єкт слотів
    public List<InventorySlot> slots = new List<InventorySlot>(); //список для запису предметів
    public List<ItemScriptableObject> scriptableObjects = new List<ItemScriptableObject>(); //список для реалізаціїї збережень
    private Camera mainCamera; 
    public GameObject MenuUi; //інтерфейс меню
    public float reachDistance = 3f; //дистанція викиду променя


    void Start()
    {
        InputData = new();
        InputData = InputData.Load();
        mainCamera = Camera.main;
        
        for (int i = 0; i < inventoryPanel.childCount; i++)  //ініціалізуємо слоти
        {
            if(inventoryPanel.GetChild(i).GetComponent<InventorySlot>() != null) 
            {
                slots.Add(inventoryPanel.GetChild(i).GetComponent<InventorySlot>());
            }
        }
        LoadInventory();
    }

    void Update()
    {
        var centerPoint = new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2, 0);//центральна точка екрану
        Ray rayTake = mainCamera.ScreenPointToRay(centerPoint);
        RaycastHit hit;

        if (Input.GetKeyDown(InputData.Interact) && !MenuUi.activeInHierarchy)
        {
            if (Physics.Raycast(rayTake, out hit, reachDistance))
            {
                if (hit.collider.gameObject.GetComponent<Item>() != null) //якщо луч отримав компонент типу Item - додаємо об'єкт в інвентар
                {
                    AddItem(hit.collider.gameObject.GetComponent<Item>().item);
                    Destroy(hit.collider.gameObject); //видалення об'єкту на сцені
                }
            }
        }
    }


    private void AddItem(ItemScriptableObject _item) //метод що реалізує додаваня предмету до інвентарю
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

    private void LoadInventory() //метод що реалізує збереження предметів у інвентарі
    {
        id[3] = "0";
        for (int i = 0; i < inventoryPanel.childCount; i++)
        {
            if (id[i] != null)
            {
                int index = int.Parse(id[i]);
                AddItem(scriptableObjects[index]);
            }
        }
    }
}
