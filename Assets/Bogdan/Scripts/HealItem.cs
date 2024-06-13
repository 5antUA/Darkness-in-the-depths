using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Heal Item" , menuName ="Invenroty/Items/New Heal item")] //створення ассет меню для зручності
public class HealItem :ItemScriptableObject //клас для для розпізновання предметів-аптечок
{

    private void Start()
    {
        itemType = ItemType.Heal;
    }
}
