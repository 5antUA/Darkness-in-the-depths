using UnityEngine;


// клас, який реалізує кнопку "Назад" в головному меню
public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;             // весь ігровий об'єкт MainUI
    [SerializeField] private GameObject NewGameUI;          // весь ігровий об'єкт NewGameUI
    [SerializeField] private GameObject SettingsUI;         // весь ігровий об'єкт SettingsUI
    [SerializeField] private GameObject DevelopersUI;       // весь ігровий об'єкт DevelopersUI


    // кнопка "Назад"
    public void Back()
    {
        MainUI.SetActive(true);
        NewGameUI.SetActive(false);
        SettingsUI.SetActive(false);
        DevelopersUI.SetActive(false);
    }
}
