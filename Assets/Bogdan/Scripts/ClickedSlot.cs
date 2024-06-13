using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedSlot : MonoBehaviour //клас для збереження предметів у інвентарі
{
    public InventorySlot Item { get; set; }

    public void SetSlotItem(GameObject obj)
    {
        Item = obj.GetComponent<InventorySlot>();
    }
}
