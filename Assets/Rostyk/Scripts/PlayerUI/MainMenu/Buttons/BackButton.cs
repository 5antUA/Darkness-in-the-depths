using UnityEngine;


// ����, ���� ������ ������ "�����" � ��������� ����
public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;             // ���� ������� ��'��� MainUI
    [SerializeField] private GameObject NewGameUI;          // ���� ������� ��'��� NewGameUI
    [SerializeField] private GameObject SettingsUI;         // ���� ������� ��'��� SettingsUI
    [SerializeField] private GameObject DevelopersUI;       // ���� ������� ��'��� DevelopersUI


    // ������ "�����"
    public void Back()
    {
        MainUI.SetActive(true);
        NewGameUI.SetActive(false);
        SettingsUI.SetActive(false);
        DevelopersUI.SetActive(false);
    }
}
