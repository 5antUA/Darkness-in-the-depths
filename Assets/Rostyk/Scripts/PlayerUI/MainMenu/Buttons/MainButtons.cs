using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ Õ¿  ¿Õ¬¿— ¬ √À¿¬ÕŒÃ Ã≈Õﬁ
public class MainButtons : MonoBehaviour
{
    SavedData.CharacterData CharacterData;
    
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;
    [SerializeField] private GameObject BlackScreen;

    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Image Skull;

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

        LoadingScreen.SetActive(true);
        AsyncOperation LoadAsync = SceneManager.LoadSceneAsync("RostykScene");
        while (!LoadAsync.isDone)
        {
            Skull.fillAmount = LoadAsync.progress;
            yield return null;
        }
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
