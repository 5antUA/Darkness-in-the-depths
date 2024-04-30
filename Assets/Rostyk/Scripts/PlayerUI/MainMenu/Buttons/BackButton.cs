using UnityEngine;


public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;

    public void Back()
    {
        MainUI.SetActive(true);
        SettingsUI.SetActive(false);
        DevelopersUI.SetActive(false);
    }
}
