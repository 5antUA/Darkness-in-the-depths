using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickIconSetDescription : MonoBehaviour
{
    public string description; //поле яке приймає опис предмета зазначений в ItemScriptableObject
    public TMP_Text textToShow; //поле яке приймає текст опису предмету в інвентарі, для подальшого змінення
    public Sprite iconGO; //поле яке приймає зображення опису предмету, для подальшого змінення

    public void OnClickSetText(GameObject SlotGO) // метод що встановлює опис предмета, при натисканні на слот
    {
       if (SlotGO.GetComponent<InventorySlot>().item != null) 
        {
            textToShow = this.GetComponent<TMP_Text>();
            description = SlotGO.GetComponent<InventorySlot>().item.itemDescriptoin;
            textToShow.text = description;
        }
        else
        {
            textToShow = this.GetComponent<TMP_Text>();
            textToShow.text = "Пустий слот";
        }
    }
    
    public void OnClickSetImage(GameObject _IconGO) //метод що встановлює описову іконку предмета збільшеного розміру, при натисканні на слот
    {
        if (_IconGO.GetComponent<Image>().sprite != null)
        {
            iconGO = _IconGO.GetComponent<Image>().sprite;
            Debug.Log(_IconGO.GetComponent<Image>().sprite);
            this.GetComponent<Image>().sprite = iconGO;
            this.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            this.GetComponent<Image>().sprite = null;
            this.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
    }

    public void onClickSetIconBackground(Sprite _BackIcon) //метод що встановлює обведення слота при натисканні
    {
        if (this.gameObject.GetComponent<Image>().sprite == null)
        {
            this.gameObject.GetComponent<Image>().sprite = _BackIcon;
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }       
       
    }

    public void setNoneBackground() //метод що анулює обведення слота при натисканні
    {
        this.gameObject.GetComponent<Image>().sprite = null;
        this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
}
