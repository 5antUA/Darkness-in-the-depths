using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//мсфмн бшапюрэ назейр щрнцн йкюяяю б яйпхоре ITEM,йнрнпши опедбюпхрекэмн бхяхр мю опетюае ухкю мю яжеме
[CreateAssetMenu(fileName = "Heal Item" , menuName ="Invenroty/Items/New Heal item")]
public class HealItem :ItemScriptableObject
{
    public float healAmount;

    private void Start()
    {
        itemType = ItemType.Heal;
    }
}
