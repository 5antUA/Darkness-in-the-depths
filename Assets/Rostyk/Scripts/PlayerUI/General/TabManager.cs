using UnityEngine;
using RostykEnums; // custom namespace


// ������ ������ �� ������ Buttons
public class TabManager : MonoBehaviour
{
    [SerializeField] private Transform TabsUI;                  // ������ (������) �������� UI �� ������� Tabs
    private TabMenu MyTab;                                          // �������� ������� ������


    private void Start()
    {
        // � ������ ���� ������� ������ �������
        MyTab = TabMenu.Dev;

        // ����� ���� ������������ �������� UI �� ��������� �������
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }


    // ��������� ������� ��������� (����� ������� ������)
    public void ActiveTabInventory()
    {
        ActiveTab(0);
        MyTab = TabMenu.Inventory;
    }

    // ��������� ������� ������� (����� ������� ������)
    public void ActiveTabNotes()
    {
        ActiveTab(1);
        MyTab = TabMenu.Notes;
    }

    // ��������� ������� ����� (����� ������� ������)
    public void ActiveTabMap()
    {
        ActiveTab(2);
        MyTab = TabMenu.Map;
    }

    // ��������� ������� �������� (����� ������� ������)
    public void ActiveTabSettings()
    {
        ActiveTab(3);
        MyTab = TabMenu.Settings;
    }

    // ��������� ������� ������������ (����� ������� ������)
    public void ActiveTabDev()
    {
        ActiveTab(4);
        MyTab = TabMenu.Dev;
    }

    // ��������� �������
    private void ActiveTab(int index)
    {
        TabsUI.GetChild((int)MyTab).gameObject.SetActive(false);
        TabsUI.GetChild(index).gameObject.SetActive(true);
    }
}
