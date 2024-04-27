using System;
using UnityEngine;
using UnityEngine.SceneManagement;


// ������ �� ������ � ������� ����
public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject Background;         // ������ background � ������� ����
    [SerializeField] private GameObject SettingsTab;        // ������� ��������
    [SerializeField] private GameObject DevelopersTab;      // ������� �� ������� ������������� ����


    private void Start()
    {
        Background.SetActive(true);
        SettingsTab.SetActive(false);
        DevelopersTab.SetActive(false);
    }


    // ������� � ������� �����, ����������� ���� (����� ������� ������)
    public void ContinueButton()
    {
        SceneManager.LoadScene("RostykScene");
    }

    // ������� � ������� �����, ����� ���� (����� ������� ������)
    public void NewGameButton()
    {
        return; // �� ������
    }

    // ������� � ���� �������� (����� ������� ������)
    public void SettingsButton()
    {
        Background.SetActive(false);
        SettingsTab.SetActive(true);
    }

    // ������� � ���� �� ������� ������������� (����� ������� ������)
    public void DevelopersButton()
    {
        Background.SetActive(false);
        DevelopersTab.SetActive(true);
    }

    // ����� � ������� ���� (����� ������� ������)
    public void BackMenu()
    {
        Background.SetActive(true);
        SettingsTab.SetActive(false);
        DevelopersTab.SetActive(false);
    }

    // ����� �� ���� (����� ������� ������)
    public void ExitButton()
    {
        Application.Quit();
    }
}
