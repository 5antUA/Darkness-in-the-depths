using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// Вішати на канвас в головному меню
public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;                 // весь ігровий об'єкт MainUI
    [SerializeField] private GameObject SettingsUI;             // весь ігровий об'єкт SettingsUI
    [SerializeField] private GameObject DevelopersUI;           // весь ігровий об'єкт DevelopersUI
    [SerializeField] private GameObject BlackScreen;            // напівпрозорий чорний екран
    [SerializeField] private GameObject ConfirmExitScreen;      // UI елемент (підтвердження дії)

    private SavedData.CharacterData CharacterData;              // ігрові дані про персонажа


    private void Start()
    {
        CharacterData = new SavedData.CharacterData();
        CharacterData = CharacterData.Load();
    }


    // кнопка для продовження гри
    public void ContinueGame()
    {
        BlackScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadGame());
    }

    // кнопка для відкриття меню налаштувань
    public void OpenSettings()
    {
        MainUI.SetActive(false);
        SettingsUI.SetActive(true);
        DevelopersUI.SetActive(false);
    }

    // кнопка для виклику вікна підтвердження виходу з гри
    public void QuitApplication()
    {
        ConfirmExitScreen.SetActive(true);
    }

    // кнопка "Так" в підтвердженні
    public void QuitApplicationYes()
    {
        Application.Quit();
    }

    // кнопка "Ні" в підтвердженні
    public void QuitApplicationNo()
    {
        ConfirmExitScreen.SetActive(false);
    }

    // асинхронна функція для запуску екрану загрузки
    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoadScene");
    }
}
