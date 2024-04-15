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


    public void ActiveTabInventory()
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(0).gameObject.SetActive(true);
        MyTab = Tab.Inventory;
    }

    public void ActiveTabNotes()
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(1).gameObject.SetActive(true);
        MyTab = Tab.Notes;
    }

    public void ActiveTabMap()
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(2).gameObject.SetActive(true);
        MyTab = Tab.Map;
    }

    public void ActiveTabSettings()
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(3).gameObject.SetActive(true);
        MyTab = Tab.Settings;
    }

    public void ActiveTabDev()
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(4).gameObject.SetActive(true);
        MyTab = Tab.Dev;
    }
}
