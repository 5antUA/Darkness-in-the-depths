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
        //��������� ��� "PLAYER" �� ������� ���������!
        player = GameObject.FindGameObjectWithTag("Player").transform;


    }
    private void Update()
    {
        // ������� ������ InventorySlot � ����� � ��������
        oldSlot = this.GetComponent<ClickedSlot>().Item;
        


    }

    public void OnClickDropItem()
    {
        if (oldSlot.isEmpty)
            return;
        // ������ �������� �� ��������� - ������� ������ ������ ����� ����������
        GameObject itemObject = Instantiate(oldSlot.item.itemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);

        // ������� �������� InventorySlot
        NullifySlotData();
        

        
    }
    void NullifySlotData()
    {
        // ������� �������� InventorySlot
        oldSlot.item = null;
        oldSlot.isEmpty = true;
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        oldSlot.iconGO.GetComponent<Image>().sprite = null;
        textToShow.text = "������ ����";
        iconGO.sprite = null;
        iconGO.color = new Color(1, 1, 1, 0);

    }
}
