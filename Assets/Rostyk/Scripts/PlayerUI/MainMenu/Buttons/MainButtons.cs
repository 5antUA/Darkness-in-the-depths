using UnityEngine;
using UnityEngine.SceneManagement;


// ¬≈ÿ¿“‹ Õ¿  ¿Õ¬¿— ¬ √À¿¬ÕŒÃ Ã≈Õﬁ
public class MainButtons : MonoBehaviour
{
    SavedData.InitializationData InitializationData;
    
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;

    private void Start()
    {
        InitializationData = new SavedData.InitializationData();
        InitializationData = InitializationData.Load();
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("RostykScene");
    }

    public void NewGame()
    {
        SavedData.PlayerData playerData = new SavedData.PlayerData();
        SavedData.NotesData notesData = new SavedData.NotesData();
        InitializationData.isContinueGame = true;
        
        playerData.Save();
        notesData.Save();
        InitializationData.Save();

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
