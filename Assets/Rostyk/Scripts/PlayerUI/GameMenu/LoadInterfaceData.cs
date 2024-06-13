using UnityEngine;
using UnityEngine.UI;


public class LoadInterfaceData : MonoBehaviour
{
    private SavedData.InterfaceData _interfaceData;         // дані про ігровий інтерфейс

    [SerializeField] private Texture[] MenuThemes;          // масив тем ігрового меню (біла та темна)
    [SerializeField] private RawImage MenuTheme;            // ігрова тема меню на даний момент
    [SerializeField] private RawImage[] Buttons;            // масив іконок кнопок
    [Space]
    [SerializeField] private Texture[] TabsThemes;          // масив тем кнопок ігрового меню (біла та темна)
    [SerializeField] private RawImage[] TextingTabs;
    [SerializeField] private Texture[] ButtonsSprites;      // масив іконок кнопок на даний момент


    private void Start()
    {
        _interfaceData = new SavedData.InterfaceData();
        _interfaceData = _interfaceData.Load();
        LoadMenuThemes();
    }

    // метод, який визначає тему ігрового меню на запуску гри
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
