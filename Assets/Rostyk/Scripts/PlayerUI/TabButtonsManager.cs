using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RostykEnums; // custom namespace

public class TabButtonsManager : MonoBehaviour
{
    [SerializeField] private Button TabDevButton;               // ������ ��� �������� ������� ������������
    [SerializeField] private Button TabInventoryButton;         // ������ ��� �������� ������� ���������
    [SerializeField] private Button TabNotesButton;             // ������ ��� �������� ������� �������
    [SerializeField] private Button TabMapButton;               // ������ ��� �������� ������� �����
    [SerializeField] private Button TabSettingsButton;          // ������ ��� �������� ������� ��������

    [SerializeField] private Transform TabsUI;                  // ������ (������) �������� UI �� ������� Tabs
    private Tab MyTab;                                          // �������� ������� ������


    private void Start()
    {
        // � ������ ���� �������� ������ - ���������
        MyTab = Tab.Inventory;

        // ����� ���� ������������ �������� UI �� ��������� �������
        for (int i = 1; i < TabsUI.childCount; i++)
        {
            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }


    // ��������� ������� ��������� (����� ������� ������)
    public void ActiveTabInventory()
    {
        ActiveTab(0);
        MyTab = Tab.Inventory;
    }

    // ��������� ������� ������� (����� ������� ������)
    public void ActiveTabNotes()
    {
        ActiveTab(1);
        MyTab = Tab.Notes;
    }

    // ��������� ������� ����� (����� ������� ������)
    public void ActiveTabMap()
    {
        ActiveTab(2);
        MyTab = Tab.Map;
    }

    // ��������� ������� �������� (����� ������� ������)
    public void ActiveTabSettings()
    {
        ActiveTab(3);
        MyTab = Tab.Settings;
    }

    // ��������� ������� ������������ (����� ������� ������)
    public void ActiveTabDev()
    {
        ActiveTab(4);
        MyTab = Tab.Dev;
    }

    // ��������� �������
    private void ActiveTab(int index)
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(index).gameObject.SetActive(true);
    }
}
