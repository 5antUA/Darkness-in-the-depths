using UnityEngine;
using UnityEngine.UI;


public class InterfaceButtons : MonoBehaviour
{
    private SavedData.InterfaceData InterfaceData;

    [SerializeField] private Toggle isLightTheme;

    private void Start()
    {
        InterfaceData = new SavedData.InterfaceData();
        InterfaceData = InterfaceData.Load();

        isLightTheme.isOn = InterfaceData.isLightTheme;
    }

    public void ToogleLightTheme()
    {
        InterfaceData.isLightTheme = isLightTheme.isOn;
        InterfaceData.Save();
    }
}
