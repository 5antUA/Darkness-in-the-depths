using UnityEngine;
using UnityEngine.UI;


public class InterfaceButtons : MonoBehaviour
{
    private SavedData.InterfaceData InterfaceData;

    [SerializeField] private Toggle IsLightThemeToggle;
    [SerializeField] private Toggle IsNegativeSensitivityToggle;

    [SerializeField] private Slider PlayerFarSlider;
    [SerializeField] private Slider PlayerSensitivitySlider;

    [SerializeField] private Text PlayerFarInfo;
    [SerializeField] private Text PlayerSensitivityInfo;


    private void Start()
    {
        InterfaceData = new();
        InterfaceData = InterfaceData.Load();

        IsLightThemeToggle.isOn = InterfaceData.isLightTheme;
        IsNegativeSensitivityToggle.isOn = InterfaceData.isNegativeSensitivity;
        PlayerFarSlider.value = InterfaceData.PlayerFar / 10;
        PlayerSensitivitySlider.value = InterfaceData.CameraSensitivity;
    }

    private void Update()
    {
        PlayerFarInfo.text = PlayerFarSlider.value.ToString();
        PlayerSensitivityInfo.text = PlayerSensitivitySlider.value.ToString();
    }


    public void ToogleLightTheme()
    {
        InterfaceData.isLightTheme = IsLightThemeToggle.isOn;
        InterfaceData.Save();
    }

    public void ToogleNegativeSensitivity()
    {
        InterfaceData.isNegativeSensitivity = IsNegativeSensitivityToggle.isOn;
        InterfaceData.Save();
    }

    public void ChangePlayerFarSlider()
    {
        InterfaceData.PlayerFar = PlayerFarSlider.value * 10;
        InterfaceData.Save();
    }

    public void ChangePlayerSensitivitySlider()
    {
        InterfaceData.CameraSensitivity = PlayerSensitivitySlider.value;
        InterfaceData.Save();
    }
}
