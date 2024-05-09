using RostykEnums;
using UnityEngine;


// ��������� MenuUI
public class LoadMenuUI : MonoBehaviour
{
    [SerializeField] private Transform TabsUI;                  // ������ (������) �������� UI �� ������� AllTabs
    private TabMenu MyTab;                                      // �������� ������� ������


    private void Start()
    {
        // � ������ ���� ������� ������ �������
        MyTab = TabMenu.Inventory;

        // ����� ���� ������������ �������� UI �� ��������� �������
        for (int i = 0; i < TabsUI.childCount; i++)
        {
            if ((int)MyTab == i)
                continue;

            TabsUI.GetChild(i).gameObject.SetActive(false);
        }
    }
}
