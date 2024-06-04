using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//мсфмн бшапюрэ назейр щрнцн йкюяяю б яйпхоре ITEM,йнрнпши опедбюпхрекэмн бхяхр мю опетюае йкчвю мю яжеме
[CreateAssetMenu(fileName = "Key item", menuName = "Invenroty/Items/New key item")]
public class KeyItem : ItemScriptableObject
{

    // Start is called before the first frame update
    void Start()
    {
        itemType = ItemType.Key;
    }


}
