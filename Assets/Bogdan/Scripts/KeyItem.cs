using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//НУЖНО ВЫБРАТЬ ОБЪЕКТ ЭТОГО КЛАССА В СКРИПТЕ ITEM,КОТОРЫЙ ПРЕДВАРИТЕЛЬНО ВИСИТ НА ПРЕФАБЕ КЛЮЧА НА СЦЕНЕ
[CreateAssetMenu(fileName = "Key item", menuName = "Invenroty/Items/New key item")]
public class KeyItem : ItemScriptableObject //клас для для розпізновання предметів типу ключ
{

    // Start is called before the first frame update
    void Start()
    {
        itemType = ItemType.Key;
    }


}
