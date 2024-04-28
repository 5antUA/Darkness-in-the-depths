using UnityEngine;
using RostykEnums;


// ВЕШАТЬ НА SettingsButtons
public class SettingsButtons : MonoBehaviour
{
    [SerializeField] private Transform TabsUI;          // список (массив) объектов UI
    [SerializeField] private Secret SecretScript;       // получать с лого игры
    private TabMainMenu MyTab;

    private void Start()
    {
        MyTab = TabMainMenu.Control;

        // через цикл деактивируем елементы UI из остальных вкладок
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }


    // Открытие меню настроек управления (метод нажатия кнопки)
    public void OpenControlTab()
    {
        ActiveTab(0);
        MyTab = TabMainMenu.Control;
    }

    // Открытие меню настроек графики (метод нажатия кнопки)
    public void OpenGraphicsTab()
    {
        ActiveTab(1);
        MyTab = TabMainMenu.Graphics;
    }

    // Открытие меню смены языка (метод нажатия кнопки)
    public void OpenLanguageTab()
    {
        ActiveTab(2);
        MyTab = TabMainMenu.Language;
    }

    // ? ? ?
    public void OpenSecretTab()
    {
        if (SecretScript.TouchCount >= 10)
        {
            ActiveTab(3);
            MyTab = TabMainMenu.Secret;
        }
    }

    // Активация меню (общий метод)
    private void ActiveTab(int index)
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(index).gameObject.SetActive(true);
    }
}
