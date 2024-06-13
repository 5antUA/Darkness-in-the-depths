using UnityEngine;
using UnityEngine.UI;


public class InterfaceButtons : MonoBehaviour
{
    [SerializeField] private Toggle IsLightThemeToggle;                 // Toggle ��� ���� ���� �������� ����
    [SerializeField] private Toggle IsNegativeSensitivityToggle;        // Toggle ��� ������� ���� ����
    [SerializeField] private Slider PlayerFarSlider;                    // Slider ��� ���� �������� ����������
    [SerializeField] private Slider PlayerSensitivitySlider;            // Slider ��� ���� ��������� �������� ������
    [SerializeField] private Text PlayerFarInfo;                        // �������� ���������� ��� PlayerFarSlider
    [SerializeField] private Text PlayerSensitivityInfo;                // �������� ���������� ��� PlayerSensitivitySlider

    private SavedData.InterfaceData _interfaceData;                     // ����� ��� ��� ���������


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


    // ������� ��� ���� ���� �������� ����
    public void ToogleLightTheme()
    {
        _interfaceData.isLightTheme = IsLightThemeToggle.isOn;
        _interfaceData.Save();
    }

    // ������� ��� ������� ���� ����
    public void ToogleNegativeSensitivity()
    {
        _interfaceData.isNegativeSensitivity = IsNegativeSensitivityToggle.isOn;
        _interfaceData.Save();
    }

    // ������� ��� ���� �������� ����������
    public void ChangePlayerFarSlider()
    {
        _interfaceData.PlayerFar = PlayerFarSlider.value * 10;
        _interfaceData.Save();
    }

    // ������� ��� ���� ��������� �������� ������
    public void ChangePlayerSensitivitySlider()
    {
        _interfaceData.CameraSensitivity = PlayerSensitivitySlider.value;
        _interfaceData.Save();
    }
}
