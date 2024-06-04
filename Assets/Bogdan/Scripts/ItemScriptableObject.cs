using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { 
    Weapon = 0,
    Heal = 1,
    Key = 2
} 
public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public GameObject itemPrefab;
    public string itemDescriptoin;
    public Sprite icon;
    public string id;


}
