using UnityEngine;


// ³���� ������ �� ��'��� TabsUI/MapUI/Buttons
public class MapManager : MonoBehaviour
{
    [SerializeField] private Transform Floors;      // ����� UI ��������
    private int _floor = 2;                         // ������ �� ������������ (3�, ���� � ����)

    private void Start()
    {
        DeactivateMaps();
    }

    // ����������� ��� ������� ��'���� � MapsUI
    private void DeactivateMaps()
    {
        for (int i = 0; i < Floors.childCount; i++)
        {
            if (i == 2)
                break;

            Floors.GetChild(i).gameObject.SetActive(false);
        }
    }

    // ������ ���� ������� (���� �������)
    public void ChangeFloorRight()
    {
        if (_floor == Floors.childCount - 1)
            return;

        Floors.GetChild(_floor).gameObject.SetActive(false);
        _floor++;
        Floors.GetChild(_floor).gameObject.SetActive(true);
    }

    // ������ ���� ������� (���� �����)
    public void ChangeFloorLeft()
    {
        if (_floor == 0)
            return;

        Floors.GetChild(_floor).gameObject.SetActive(false);
        _floor--;
        Floors.GetChild(_floor).gameObject.SetActive(true);
    }
}
