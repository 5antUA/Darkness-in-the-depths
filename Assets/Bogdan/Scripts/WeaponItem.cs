using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//����� ������� ������ ����� ������ � ������� ITEM,������� �������������� ����� �� ������� ������ �� �����
[CreateAssetMenu(fileName = "Weapon item", menuName = "Invenroty/Items/New weapon item")]
public class WeaponItem : ItemScriptableObject //���� ��� ��� ������������ ��������-�������
{

    private void Start()
    {
        itemType = ItemType.Weapon;
    }
}

