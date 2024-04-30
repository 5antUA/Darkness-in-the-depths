using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;
    [SerializeField] private GameObject SettingsUI;
    [SerializeField] private GameObject DevelopersUI;

    private void Start()
    {
        MainUI.SetActive(true);
        SettingsUI.SetActive(false);
        DevelopersUI.SetActive(false);
    }
}
