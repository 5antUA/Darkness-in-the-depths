using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// ¬≈ÿ¿“‹ Õ¿  ¿Õ¬¿— ¬ √À¿¬ÕŒÃ Ã≈Õﬁ
public class MainButtons : MonoBehaviour
{
    SavedData.CharacterData CharacterData;
    
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;
    [SerializeField] private GameObject BlackScreen;

    private void Start()
    {
        CharacterData = new SavedData.CharacterData();
        CharacterData = CharacterData.Load();
    }

    public void ContinueGame()
    {
        BlackScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("RostykScene");
    }

    public void OpenSettings()
    {
        MainUI.SetActive(false);
        SettingsUI.SetActive(true);
        DevelopersUI.SetActive(false);
    }

    public void OpenDevInfo()
    {
        MainUI.SetActive(false);
        SettingsUI.SetActive(false);
        DevelopersUI.SetActive(true);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
