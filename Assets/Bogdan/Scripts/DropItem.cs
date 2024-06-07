using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DropItem : MonoBehaviour
{
    public InventorySlot oldSlot;
    private Transform player;
    public TMP_Text textToShow;
    public Image iconGO;
    public Player character;
    public Button buttonDrop;
    public Button buttonUse;
    private bool isHeal = false;
    private void Start()
    {
        //��������� ��� "PLAYER" �� ������� ���������!
        player = GameObject.FindGameObjectWithTag("Player").transform;
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();




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
    public void OnUseHeal()
    {
        
        if(oldSlot.item != null && oldSlot.item.itemType == ItemType.Heal)
        {
            Debug.Log(oldSlot.item.itemType);
            if ((character.Health + oldSlot.item.healAmount) > character.MaxCharacterHealth)
            {
                character.Health = character.MaxCharacterHealth;
            }
            else
            {
                character.Health += oldSlot.item.healAmount;
            }

            // ������� �������� InventorySlot
            NullifySlotData();

        }
        //if (isHeal)
        //{
        //    return;
        //}


        




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
    public void onClickActiveButton(InventorySlot SlotGO)
    {
        if (SlotGO.item != null && SlotGO.item.itemType == ItemType.Heal )
        {
            buttonDrop.interactable = true;
            buttonUse.interactable = true;
        }
        else if(SlotGO.item !=null)
        {
            Debug.Log("s");
            buttonDrop.interactable = true;
            buttonUse.interactable = false;
        }
        else
        {
            buttonDrop.interactable = false;
            buttonUse.interactable = false;
        }
    }
}
