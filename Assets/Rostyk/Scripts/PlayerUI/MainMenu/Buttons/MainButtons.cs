using UnityEngine;
using UnityEngine.SceneManagement;


// ¬≈ÿ¿“‹ Õ¿  ¿Õ¬¿— ¬ √À¿¬ÕŒÃ Ã≈Õﬁ
public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;

    public void ContinueGame()
    {
        SceneManager.LoadScene("RostykScene");
    }

    public void NewGame()
    {
        SavedData.PlayerData playerData = new SavedData.PlayerData();
        SavedData.NotesData notesData = new SavedData.NotesData();
        playerData.Save();
        notesData.Save();

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
