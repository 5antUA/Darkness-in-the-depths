using RostykEnums;
using SavedData;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// ВЕШАТЬ СКРИП НА ОБЪЕКТ PlayerUI
public class HealthBarManager : MonoBehaviour
{
    private SavedData.CharacterData CharacterData;
    private SavedData.InputData InputData;

    public GameObject HealthBar;

    [Space]
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // скрипт this.Player

    [Header("\t Initialition data")]
    [Space]
    [SerializeField] private Text PlayerInfoText;
    [SerializeField] private Text PlayerName;
    [SerializeField] private Image StrokeBarImage;
    [SerializeField] private Image BackgroundBarImage;
    [SerializeField] private Image HealthBarImage;
    [SerializeField] private Image PlayerIcon;

    [SerializeField] private Sprite KovalevIcon;
    [SerializeField] private Sprite ValentinIcon;
    [SerializeField] private Sprite RomarioIcon;
    [SerializeField] private Sprite PaniniIcon;


    private void Awake()
    {
        CharacterData = new SavedData.CharacterData();
        InputData = new SavedData.InputData();
        CharacterData = CharacterData.Load();
        InputData = InputData.Load();
    }
    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        InitData();
        DefinePlayerName();
    }

    private void Update()
    {
        if (HealthBar.activeInHierarchy)
            UpdatePlayerInfo();
    }


    // Обновление данных игрока
    private void UpdatePlayerInfo()
    {
        int healthInfo = (int)MyPlayer.Health;
        HealthBarImage.fillAmount = MyPlayer.Health / MyPlayer.MaxCharacterHealth;

        if (MyPlayer.IsDead)
            healthInfo = 0;

        PlayerInfoText.text =
            $"Health : {healthInfo}\n";
    }

    private void DefinePlayerName()
    {
        switch (CharacterData.Character)
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

    private void InitData()
    {
        switch (CharacterData.Character)
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
