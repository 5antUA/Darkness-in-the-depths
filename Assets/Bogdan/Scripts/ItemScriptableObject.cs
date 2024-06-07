using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { 
    Weapon,
    Heal,
    Key
} 
public class ItemScriptableObject : ScriptableObject
{
    public ItemType itemType;
    public string itemName;
    public GameObject itemPrefab;
    public string itemDescriptoin;
    public Sprite icon;
    public string id;
    public float healAmount;


}
