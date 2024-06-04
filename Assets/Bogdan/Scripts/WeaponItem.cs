using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//мсфмн бшапюрэ назейр щрнцн йкюяяю б яйпхоре ITEM,йнрнпши опедбюпхрекэмн бхяхр мю опетюае нпсфхъ мю яжеме
[CreateAssetMenu(fileName = "Weapon item", menuName = "Invenroty/Items/New weapon item")]
public class WeaponItem : ItemScriptableObject
{

    private void Start()
    {
        itemType = ItemType.Weapon;
    }
}

