using UnityEngine;
using UnityEngine.UI;

public class LoadInterfaceData : MonoBehaviour
{
    private SavedData.InterfaceData InterfaceData;

    [SerializeField] private Texture[] MenuThemes;
    [SerializeField] private RawImage MenuTheme;
    [SerializeField] private RawImage[] Buttons;
    [Space]
    [SerializeField] private Texture[] TabsThemes;
    [SerializeField] private RawImage[] TextingTabs;
    [SerializeField] private Texture[] ButtonsSprites;

    private void Start()
    {
        InterfaceData = new SavedData.InterfaceData();
        InterfaceData = InterfaceData.Load();

        LoadMenuThemes();
    }

    private void LoadMenuThemes()
    {
        MenuTheme.texture =
            InterfaceData.isLightTheme ?
            MenuThemes[0] :
            MenuThemes[1];

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].texture =
                InterfaceData.isLightTheme ?
                ButtonsSprites[0] :
                ButtonsSprites[1];
        }

        for (int i = 0; i < TextingTabs.Length; i++)
        {
            TextingTabs[i].texture =
                InterfaceData.isLightTheme ?
                TabsThemes[0] :
                TabsThemes[1];
        }
    }
}
