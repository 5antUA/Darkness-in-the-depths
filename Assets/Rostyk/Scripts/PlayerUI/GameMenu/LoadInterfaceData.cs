using UnityEngine;
using UnityEngine.UI;


public class LoadInterfaceData : MonoBehaviour
{
    private SavedData.InterfaceData _interfaceData;         // ��� ��� ������� ���������

    [SerializeField] private Texture[] MenuThemes;          // ����� ��� �������� ���� (��� �� �����)
    [SerializeField] private RawImage MenuTheme;            // ������ ���� ���� �� ����� ������
    [SerializeField] private RawImage[] Buttons;            // ����� ������ ������
    [Space]
    [SerializeField] private Texture[] TabsThemes;          // ����� ��� ������ �������� ���� (��� �� �����)
    [SerializeField] private RawImage[] TextingTabs;
    [SerializeField] private Texture[] ButtonsSprites;      // ����� ������ ������ �� ����� ������


    private void Start()
    {
        _interfaceData = new SavedData.InterfaceData();
        _interfaceData = _interfaceData.Load();
        LoadMenuThemes();
    }

    // �����, ���� ������� ���� �������� ���� �� ������� ���
    private void LoadMenuThemes()
    {
        MenuTheme.texture =
            _interfaceData.isLightTheme ?
            MenuThemes[0] :
            MenuThemes[1];

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].texture =
                _interfaceData.isLightTheme ?
                ButtonsSprites[0] :
                ButtonsSprites[1];
        }

        for (int i = 0; i < TextingTabs.Length; i++)
        {
            TextingTabs[i].texture =
                _interfaceData.isLightTheme ?
                TabsThemes[0] :
                TabsThemes[1];
        }
    }
}
