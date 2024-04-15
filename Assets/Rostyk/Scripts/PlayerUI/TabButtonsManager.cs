using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RostykEnums; // custom namespace

public class TabButtonsManager : MonoBehaviour
{
    [SerializeField] private Button TabDevButton;               // кнопка для открытия вкладки разработчика
    [SerializeField] private Button TabInventoryButton;         // кнопка для открытия вкладки инвентаря
    [SerializeField] private Button TabNotesButton;             // кнопка для открытия вкладки записок
    [SerializeField] private Button TabMapButton;               // кнопка для открытия вкладки карты
    [SerializeField] private Button TabSettingsButton;          // кнопка для открытия вкладки настроек

    [SerializeField] private Transform TabsUI;                  // список (массив) объектов UI из вкладки Tabs
    private Tab MyTab;                                          // выбраная вкладка сейчас


    private void Start()
    {
        // в начале игры выбраная владка - инвертарь
        MyTab = Tab.Inventory;

        // через цикл деактивируем елементы UI из остальных вкладок
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
