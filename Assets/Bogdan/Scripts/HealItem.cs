using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����� ������� ������ ����� ������ � ������� ITEM,������� �������������� ����� �� ������� ���� �� �����
[CreateAssetMenu(fileName = "Heal Item" , menuName ="Invenroty/Items/New Heal item")]
public class HealItem :ItemScriptableObject
{
    public float healAmount;

    private void Start()
    {
        itemType = ItemType.Heal;
    }
}
