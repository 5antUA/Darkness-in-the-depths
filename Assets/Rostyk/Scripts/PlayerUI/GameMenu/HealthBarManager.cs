using RostykEnums;
using UnityEngine;
using UnityEngine.UI;


// Вішати скрипт на ігровий об'єкт PlayerUI
// клас для управління HealthBar
public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Text PlayerInfoText;           // текстова інформація про здоров'я гравця
    [SerializeField] private Text PlayerName;               // текстова інформація про ім'я гравця
    [SerializeField] private Image StrokeBarImage;          // обводка HealthBar
    [SerializeField] private Image BackgroundBarImage;      // задній фон HeaalthBar
    [SerializeField] private Image HealthBarImage;          // кількість Health в HealthBar
    [SerializeField] private Image PlayerIcon;              // іконка персонажа
    [SerializeField] private Sprite KovalevIcon;            // спрайт іконки персонажа Владіслейв
    [SerializeField] private Sprite ValentinIcon;           // спрайт іконки персонажа Валентин
    [SerializeField] private Sprite RomarioIcon;            // спрайт іконки персонажа Ромаріо Десантес
    [SerializeField] private Sprite PaniniIcon;             // спрайт іконки персонажа Містер Бігуді

    public GameObject HealthBar;                            // весь ігровий об'єкт HealthBar
    public GameObject MenuUI;                               // весь ігровий об'єкт MenuUI

    private Player _player;                                 // скрипт _player
    private SavedData.CharacterData _characterData;         // ігрові дані про персонажа
    private SavedData.InputData _inputData;                 // ігрові дані про клавіші


    private void Awake()
    {
        _characterData = new SavedData.CharacterData();
        _inputData = new SavedData.InputData();
        _characterData = _characterData.Load();
        _inputData = _inputData.Load();
    }
    private void Start()
    {
        _player = GetComponentInParent<Player>();
        InitHealthBarCustomization();
        DefinePlayerName();
    }

    private void Update()
    {
        if (HealthBar.activeInHierarchy)
            UpdatePlayerInfo();
    }


    // Оновлення даних на HealthBar
    private void UpdatePlayerInfo()
    {
        int healthInfo = (int)_player.Health;
        HealthBarImage.fillAmount = _player.Health / _player.MaxCharacterHealth;

        if (_player.IsDead)
            healthInfo = 0;

        PlayerInfoText.text =
            $"Health : {healthInfo}\n";
    }

    // функція визначення імені персонажа
    private void DefinePlayerName()
    {
        switch (_characterData.Character)
        {
            case Characters.Valentin:
                PlayerName.text = "Валентин";
                break;
            case Characters.Kovalev:
                PlayerName.text = "Владіслейв";
                break;
            case Characters.Romario:
                PlayerName.text = "Ромаріо Десантес";
                break;
            case Characters.Panini:
                PlayerName.text = "Містер Бігуді";
                break;
        }
    }

    // ініціалізація елементів UI в HealthBar при запуску гри
    private void InitHealthBarCustomization()
    {
        switch (_characterData.Character)
        {
            case Characters.Valentin:
                PlayerIcon.sprite = ValentinIcon;
                break;
            case Characters.Kovalev:
                PlayerIcon.sprite = KovalevIcon;
                break;
            case Characters.Romario:
                PlayerIcon.sprite = RomarioIcon;
                break;
            case Characters.Panini:
                UnityEngine.ColorUtility.TryParseHtmlString("#BEBEBE", out Color newBackgroundBarColor);
                UnityEngine.ColorUtility.TryParseHtmlString("#676767", out Color newHealthBarColor);
                PlayerIcon.sprite = PaniniIcon;
                HealthBarImage.color = newHealthBarColor;
                BackgroundBarImage.color = newBackgroundBarColor;
                break;
        }
    }
}
