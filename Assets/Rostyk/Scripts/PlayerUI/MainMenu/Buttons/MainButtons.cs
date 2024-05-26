using UnityEngine;
using UnityEngine.SceneManagement;


// ¬≈ÿ¿“‹ Õ¿  ¿Õ¬¿— ¬ √À¿¬ÕŒÃ Ã≈Õﬁ
public class MainButtons : MonoBehaviour
{
    SavedData.CharacterData CharacterData;
    
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;

    private void Start()
    {
        CharacterData = new SavedData.CharacterData();
        CharacterData = CharacterData.Load();
    }

    public void LoadVladScene()
    {
        SavedData.PlayerPositionData playerData = new SavedData.PlayerPositionData();

        playerData.Save();

        SceneManager.LoadScene("gym");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("RostykScene");
    }

    public void NewGame()
    {
        SavedData.PlayerPositionData playerData = new SavedData.PlayerPositionData();
        SavedData.NotesData notesData = new SavedData.NotesData();
        CharacterData.isContinueGame = true;
        
        playerData.Save();
        notesData.Save();
        CharacterData.Save();

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
