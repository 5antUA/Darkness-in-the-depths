using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropItem : MonoBehaviour
{
    public InventorySlot oldSlot;
    private Transform player;
    public TMP_Text textToShow;
    public Image iconGO;


    private void Start()
    {
        //ПОСТАВЬТЕ ТЭГ "PLAYER" НА ОБЪЕКТЕ ПЕРСОНАЖА!
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }
    private void Update()
    {
        // Находим скрипт InventorySlot в слоте в иерархии
        oldSlot = this.GetComponent<ClickedSlot>().Item;
        


    }

    public void OnClickDropItem()
    {
        if (oldSlot.isEmpty)
            return;
        // Выброс объектов из инвентаря - Спавним префаб обекта перед персонажем
        GameObject itemObject = Instantiate(oldSlot.item.itemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);

        // убираем значения InventorySlot
        NullifySlotData();
        

        
    }
    void NullifySlotData()
    {
        // убираем значения InventorySlot
        oldSlot.item = null;
        oldSlot.isEmpty = true;
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        oldSlot.iconGO.GetComponent<Image>().sprite = null;
        textToShow.text = "Пустий слот";
        iconGO.sprite = null;
        iconGO.color = new Color(1, 1, 1, 0);

    }
}
