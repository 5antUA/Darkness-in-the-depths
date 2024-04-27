using UnityEngine;
using RostykEnums; // custom namespace


// ВЕШАТЬ СКРИПТ НА ОБЪЕКТ Buttons
public class TabManager : MonoBehaviour
{
    [SerializeField] private Transform TabsUI;                  // список (массив) объектов UI из вкладки Tabs
    private TabMenu MyTab;                                          // выбраная вкладка сейчас


    private void Start()
    {
        // в начале игры выбрана данная вкладка
        MyTab = TabMenu.Dev;

        // через цикл деактивируем елементы UI из остальных вкладок
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }


    // Активация вкладки инвентаря (метод нажатия кнопки)
    public void ActiveTabInventory()
    {
        ActiveTab(0);
        MyTab = TabMenu.Inventory;
    }

    // Активация вкладки записок (метод нажатия кнопки)
    public void ActiveTabNotes()
    {
        ActiveTab(1);
        MyTab = TabMenu.Notes;
    }

    // Активация вкладки карты (метод нажатия кнопки)
    public void ActiveTabMap()
    {
        ActiveTab(2);
        MyTab = TabMenu.Map;
    }

    // Активация вкладки настроек (метод нажатия кнопки)
    public void ActiveTabSettings()
    {
        ActiveTab(3);
        MyTab = TabMenu.Settings;
    }

    // Активация вкладки разработчика (метод нажатия кнопки)
    public void ActiveTabDev()
    {
        ActiveTab(4);
        MyTab = TabMenu.Dev;
    }

    // Активация вкладки
    private void ActiveTab(int index)
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(index).gameObject.SetActive(true);
    }
}
