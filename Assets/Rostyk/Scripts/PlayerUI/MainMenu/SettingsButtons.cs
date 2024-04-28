using UnityEngine;
using RostykEnums;


// ������ �� SettingsButtons
public class SettingsButtons : MonoBehaviour
{
    [SerializeField] private Transform TabsUI;          // ������ (������) �������� UI
    [SerializeField] private Secret SecretScript;       // �������� � ���� ����
    private TabMainMenu MyTab;

    private void Start()
    {
        MyTab = TabMainMenu.Control;

        // ����� ���� ������������ �������� UI �� ��������� �������
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }


    // �������� ���� �������� ���������� (����� ������� ������)
    public void OpenControlTab()
    {
        ActiveTab(0);
        MyTab = TabMainMenu.Control;
    }

    // �������� ���� �������� ������� (����� ������� ������)
    public void OpenGraphicsTab()
    {
        ActiveTab(1);
        MyTab = TabMainMenu.Graphics;
    }

    // �������� ���� ����� ����� (����� ������� ������)
    public void OpenLanguageTab()
    {
        ActiveTab(2);
        MyTab = TabMainMenu.Language;
    }

    // ? ? ?
    public void OpenSecretTab()
    {
        if (SecretScript.TouchCount >= 10)
        {
            ActiveTab(3);
            MyTab = TabMainMenu.Secret;
        }
    }

    // ��������� ���� (����� �����)
    private void ActiveTab(int index)
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(index).gameObject.SetActive(true);
    }
}
