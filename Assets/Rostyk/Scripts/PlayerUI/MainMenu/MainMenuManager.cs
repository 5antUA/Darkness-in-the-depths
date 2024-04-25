using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject SettingsTab;
    [SerializeField] private GameObject DevelopersTab;

    private void Start()
    {
        Background.SetActive(true);
        SettingsTab.SetActive(false);
        DevelopersTab.SetActive(false);
    }

    public void ContinueButton()
    {

        SceneManager.LoadScene("RostykScene");
    }

    public void SettingsButton()
    {
        Background.SetActive(false);
        SettingsTab.SetActive(true);
    }

    public void DevelopersButton()
    {
        Background.SetActive(false);
        DevelopersTab.SetActive(true);
    }

    public void BackMenu()
    {
        Background.SetActive(true);
        SettingsTab.SetActive(false);
        DevelopersTab.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
