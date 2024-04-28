using UnityEngine;
using UnityEngine.SceneManagement;


// ВЕШАТЬ НА КАНВАС В ГЛАВНОМ МЕНЮ
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject Background;         // второй background в главном меню
    [SerializeField] private GameObject SettingsTab;        // подменю настроек
    [SerializeField] private GameObject DevelopersTab;      // подменю со списком разработчиков игры
    [SerializeField] private Texture2D CursorSprite;

    private void Start()
    {
        Background.SetActive(true);
        SettingsTab.SetActive(false);
        DevelopersTab.SetActive(false);
    }


    // Переход в игровую сцену, продолжение игры (метод нажатия кнопки)
    public void ContinueButton()
    {
        SceneManager.LoadScene("RostykScene");
    }

    // Переход в игровую сцену, новая игра (метод нажатия кнопки)
    public void NewGameButton()
    {
        return; // не готово
    }

    // Переход в меню настроек (метод нажатия кнопки)
    public void SettingsButton()
    {
        Background.SetActive(false);
        SettingsTab.SetActive(true);
    }

    // Переход в меню со списком разработчиков (метод нажатия кнопки)
    public void DevelopersButton()
    {
        Background.SetActive(false);
        DevelopersTab.SetActive(true);
    }

    // Выход в главное меню (метод нажатия кнопки)
    public void BackMenu()
    {
        Background.SetActive(true);
        SettingsTab.SetActive(false);
        DevelopersTab.SetActive(false);
    }

    // Выход из игры (метод нажатия кнопки)
    public void ExitButton()
    {
        Application.Quit();
    }
}
