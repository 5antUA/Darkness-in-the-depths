using UnityEngine;


public class EntryPointMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject NewGameUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        MainUI.SetActive(true);
        NewGameUI.SetActive(false);
        SettingsUI.SetActive(false);
        DevelopersUI.SetActive(false);
    }
}
