using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//НУЖНО ВЫБРАТЬ ОБЪЕКТ ЭТОГО КЛАССА В СКРИПТЕ ITEM,КОТОРЫЙ ПРЕДВАРИТЕЛЬНО ВИСИТ НА ПРЕФАБЕ ОРУЖИЯ НА СЦЕНЕ
[CreateAssetMenu(fileName = "Weapon item", menuName = "Invenroty/Items/New weapon item")]
public class WeaponItem : ItemScriptableObject //клас для для розпізновання предметів-аптечок
{

    private void Start()
    {
        itemType = ItemType.Weapon;
    }
}

