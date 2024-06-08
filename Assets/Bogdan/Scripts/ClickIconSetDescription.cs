using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickIconSetDescription : MonoBehaviour
{
    public string description;
    public TMP_Text textToShow;
    public Sprite iconGO;



   
    public void OnClickSetText(GameObject SlotGO)
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
    
    public void OnClickSetImage(GameObject _IconGO)
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
    public void onClickSetIconBackground(Sprite _BackIcon)
    {
        if (this.gameObject.GetComponent<Image>().sprite == null)
        {
            this.gameObject.GetComponent<Image>().sprite = _BackIcon;
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }       
       
    }
    public void setNoneBackground()
    {
        this.gameObject.GetComponent<Image>().sprite = null;
        this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }
}
