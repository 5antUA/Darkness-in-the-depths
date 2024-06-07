using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedSlot : MonoBehaviour
{
    public ItemScriptableObject Item { get; set; }


    public void SetSlotItem(GameObject obj)
    {
        Item = obj.GetComponent<InventorySlot>().item;
    }
}
