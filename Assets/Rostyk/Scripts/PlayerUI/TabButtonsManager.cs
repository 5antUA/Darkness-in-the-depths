using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RostykEnums; // custom namespace


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ Buttons
public class TabButtonsManager : MonoBehaviour
{
    [SerializeField] private Button TabInventoryButton;         // кнопка для открытия вкладки инвентаря
    [SerializeField] private Button TabNotesButton;             // кнопка для открытия вкладки записок
    [SerializeField] private Button TabMapButton;               // кнопка для открытия вкладки карты
    [SerializeField] private Button TabSettingsButton;          // кнопка для открытия вкладки настроек
    [SerializeField] private Button TabDevButton;               // кнопка для открытия вкладки разработчика

    [SerializeField] private Transform TabsUI;                  // список (массив) объектов UI из вкладки Tabs
    private Tab MyTab;                                          // выбраная вкладка сейчас


    private void Start()
    {
        // в начале игры выбрана данная вкладка
        MyTab = Tab.Dev;

        // через цикл деактивируем елементы UI из остальных вкладок
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }


    // активация вкладки инвентаря (метод нажатия кнопки)
    public void ActiveTabInventory()
    {
        ActiveTab(0);
        MyTab = Tab.Inventory;
    }

    // активация вкладки записок (метод нажатия кнопки)
    public void ActiveTabNotes()
    {
        ActiveTab(1);
        MyTab = Tab.Notes;
    }

    // активация вкладки карты (метод нажатия кнопки)
    public void ActiveTabMap()
    {
        ActiveTab(2);
        MyTab = Tab.Map;
    }

    // активация вкладки настроек (метод нажатия кнопки)
    public void ActiveTabSettings()
    {
        ActiveTab(3);
        MyTab = Tab.Settings;
    }

    // активация вкладки разработчика (метод нажатия кнопки)
    public void ActiveTabDev()
    {
        ActiveTab(4);
        MyTab = Tab.Dev;
    }

    // активация вкладки
    private void ActiveTab(int index)
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(index).gameObject.SetActive(true);
    }
}
