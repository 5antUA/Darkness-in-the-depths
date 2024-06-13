using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType { 
    Weapon,
    Heal,
    Key
} 
public class ItemScriptableObject : ScriptableObject //класс для опису характеристик предмету
{
    public ItemType itemType; //тип предмету
    public string itemName; //назва предмету
    public GameObject itemPrefab; //префаб предмету, для подальшої взаємодії(викидування інвентаря)
    public string itemDescriptoin; //опис предмета
    public Sprite icon; //іконка предмету
    public string id; //id предмету(для збереження)
    public float healAmount; //кількіть очків здоров'я,які відновлює предмет(якщо відновлює)


}
