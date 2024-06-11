using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


// ³���� �� ������ � ��������� ����
public class MainButtons : MonoBehaviour
{
    [SerializeField] private GameObject MainUI;                 // ���� ������� ��'��� MainUI
    [SerializeField] private GameObject SettingsUI;             // ���� ������� ��'��� SettingsUI
    [SerializeField] private GameObject DevelopersUI;           // ���� ������� ��'��� DevelopersUI
    [SerializeField] private GameObject BlackScreen;            // ������������ ������ �����
    [SerializeField] private GameObject ConfirmExitScreen;      // UI ������� (������������ 䳿)

    private SavedData.CharacterData CharacterData;              // ����� ��� ��� ���������


    private void Start()
    {
        CharacterData = new SavedData.CharacterData();
        CharacterData = CharacterData.Load();
    }


    // ������ ��� ����������� ���
    public void ContinueGame()
    {
        BlackScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(LoadGame());
    }

    // ������ ��� �������� ���� �����������
    public void OpenSettings()
    {
        MainUI.SetActive(false);
        SettingsUI.SetActive(true);
        DevelopersUI.SetActive(false);
    }

    // ������ ��� ������� ���� ������������ ������ � ���
    public void QuitApplication()
    {
        ConfirmExitScreen.SetActive(true);
    }

    // ������ "���" � �����������
    public void QuitApplicationYes()
    {
        Application.Quit();
    }

    // ������ "ͳ" � �����������
    public void QuitApplicationNo()
    {
        ConfirmExitScreen.SetActive(false);
    }

    // ���������� ������� ��� ������� ������ ��������
    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("LoadScene");
    }
}
