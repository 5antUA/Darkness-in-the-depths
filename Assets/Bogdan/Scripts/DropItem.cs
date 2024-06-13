using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        player = character.transform;
    }
    private void Update()
    {
        // Знаходимо скрипт InventorySlot в слоті в ієрархії
        oldSlot = this.GetComponent<ClickedSlot>().Item;
    }

    public void OnClickDropItem() //метод,що дозволяє викидувати предмети з інвентаря
    {
        if (oldSlot.isEmpty)
            return;
        // викидування об'ектів з інвентаря - створюємо префаб об'єкта перед персонажем
        Instantiate(oldSlot.item.itemPrefab, player.position + Vector3.up + player.forward, Quaternion.identity);
        // анулюємо значенення в InventorySlot
        NullifySlotData();
    }

    public void OnUseHeal() //метод,що дозволяє використовувати аптечки беспосередньо з інвентаря
    {
        if (oldSlot == null)
            return;

        if (oldSlot.item != null && oldSlot.item.itemType == ItemType.Heal)
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
            // анулюємо значенення в InventorySlot
            NullifySlotData();
        }
    }

    void NullifySlotData()
    {
        // анулюємо значенення в InventorySlot
        oldSlot.item = null;
        oldSlot.isEmpty = true;
        oldSlot.iconGO.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        oldSlot.iconGO.GetComponent<Image>().sprite = null;
        textToShow.text = "Пустий слот";
        iconGO.sprite = null;
        iconGO.color = new Color(1, 1, 1, 0);
    }

    public void onClickActiveButton(InventorySlot SlotGO) //метод що активує кнопки,якщо слот не пустий
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
