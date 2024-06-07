using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenSetText : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Text>().text = discriptions[GetRandomIndex()];
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, discriptions.Length);
    }


    private string[] discriptions =
{
        "� ������� ����� �� ������� �����������!",


        "������������ ������ ���� ������ ���� " +
            "���� ���� �� �� ������� �� ��� ��," +
            " ���� �� ������� ��.",


        "����� � �� ��, �� �� ������� ���������",


        "����� � �� ��������� ������� �� ��� ���!",


        "������� ���� �����, ��� �� ������� �������" +
            " ������ �������� ����� ����������.",


        "��������� ������ �� ����� ��� ���������! ���� ��" +
            " �������� �� ������� � ��� ���������� ���� " +
            "����������� �������.",


        "���� �������?",


        "� ������� ������� �������� ��������, �� ��������� " +
            "������ � �� ��� ������������ ������� ������������",


        "���������� ��� �������� �� �� ���� �������, � �� " +
            "��������� ���������. ",


        "��������� ����� �������� �� �������.",
    };
}
