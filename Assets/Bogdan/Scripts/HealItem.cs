using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Heal Item" , menuName ="Invenroty/Items/New Heal item")] //��������� ����� ���� ��� ��������
public class HealItem :ItemScriptableObject //���� ��� ��� ������������ ��������-�������
{

    private void Start()
    {
        itemType = ItemType.Heal;
    }
}
