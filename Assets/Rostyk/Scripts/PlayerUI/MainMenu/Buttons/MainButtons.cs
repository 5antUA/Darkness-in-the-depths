using UnityEngine;
using UnityEngine.SceneManagement;


// ÂÅØÀÒÜ ÍÀ ÊÀÍÂÀÑ Â ÃËÀÂÍÎÌ ÌÅÍŞ
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
        return;
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
