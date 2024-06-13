using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    
    public ItemScriptableObject item; //поле типу ScriptableObject для запису властивостей предмету
    public bool isEmpty = true; // пустий слот(або ні)
    public GameObject iconGO; //іконка предмета у інвентарі



    private void Awake()
    {
        iconGO = transform.GetChild(0).gameObject; //отриання компоненту зображення для подальшої зміни
    }
    public void SetIcon(Sprite icon) //метод,що встановлює зображення,коли предмет з'являється у інвентарі
    {
        iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        iconGO.GetComponent<Image>().sprite = icon;
    }

   
    
}
