using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� ������� ������ ����� ������ � ������� ITEM,������� �������������� ����� �� ������� ����� �� �����
[CreateAssetMenu(fileName = "Key item", menuName = "Invenroty/Items/New key item")]
public class KeyItem : ItemScriptableObject //���� ��� ��� ������������ �������� ���� ����
{

    // Start is called before the first frame update
    void Start()
    {
        itemType = ItemType.Key;
    }


}
