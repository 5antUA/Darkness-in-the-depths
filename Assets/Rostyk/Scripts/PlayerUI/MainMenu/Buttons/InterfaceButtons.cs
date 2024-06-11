using UnityEngine;
using UnityEngine.UI;


public class InterfaceButtons : MonoBehaviour
{
    [SerializeField] private Toggle IsLightThemeToggle;                 // Toggle для зміни теми ігрового меню
    [SerializeField] private Toggle IsNegativeSensitivityToggle;        // Toggle для реверсу осей миші
    [SerializeField] private Slider PlayerFarSlider;                    // Slider для зміни дальності прорисовки
    [SerializeField] private Slider PlayerSensitivitySlider;            // Slider для зміни чутливості повороту камери
    [SerializeField] private Text PlayerFarInfo;                        // текстова інформація про PlayerFarSlider
    [SerializeField] private Text PlayerSensitivityInfo;                // текстова інформація про PlayerSensitivitySlider

    private SavedData.InterfaceData _interfaceData;                     // ігрові дані про інтерфейс


    private void Start()
    {
        _interfaceData = new();
        _interfaceData = _interfaceData.Load();
        IsLightThemeToggle.isOn = _interfaceData.isLightTheme;
        IsNegativeSensitivityToggle.isOn = _interfaceData.isNegativeSensitivity;
        PlayerFarSlider.value = _interfaceData.PlayerFar / 10;
        PlayerSensitivitySlider.value = _interfaceData.CameraSensitivity;
    }

    private void Update()
    {
        PlayerFarInfo.text = PlayerFarSlider.value.ToString();
        PlayerSensitivityInfo.text = PlayerSensitivitySlider.value.ToString();
    }


    // функція для зміни теми ігрового меню
    public void ToogleLightTheme()
    {
        _interfaceData.isLightTheme = IsLightThemeToggle.isOn;
        _interfaceData.Save();
    }

    // функція для реверсу осей миші
    public void ToogleNegativeSensitivity()
    {
        _interfaceData.isNegativeSensitivity = IsNegativeSensitivityToggle.isOn;
        _interfaceData.Save();
    }

    // функція для зміни дальності прорисовки
    public void ChangePlayerFarSlider()
    {
        _interfaceData.PlayerFar = PlayerFarSlider.value * 10;
        _interfaceData.Save();
    }

    // функція для зміни чутливості повороту камери
    public void ChangePlayerSensitivitySlider()
    {
        _interfaceData.CameraSensitivity = PlayerSensitivitySlider.value;
        _interfaceData.Save();
    }
}
