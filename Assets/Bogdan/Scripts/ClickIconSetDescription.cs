using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClickIconSetDescription : MonoBehaviour
{
    public string description;
    private TMP_Text textToShow;
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
            textToShow.text = "";
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
}
