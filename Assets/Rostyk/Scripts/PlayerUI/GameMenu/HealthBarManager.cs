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
                PlayerName.text = "Влад Ковальов";
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
        if (CharacterData.Character == RostykEnums.Characters.Valentin)
        {
            PlayerIcon.sprite = ValentinIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#0B8C00", out Color newHealthBarColor);
            UnityEngine.ColorUtility.TryParseHtmlString("#595959", out Color newBackgroundBarColor);
            HealthBarImage.color = newHealthBarColor;

            StrokeBarImage.color = Color.black;
            BackgroundBarImage.color = newBackgroundBarColor;
        }
        else if (CharacterData.Character == RostykEnums.Characters.Kovalev)
        {
            PlayerIcon.sprite = KovalevIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#007BFF", out Color newHealthBarColor);
            UnityEngine.ColorUtility.TryParseHtmlString("#595959", out Color newBackgroundBarColor);
            HealthBarImage.color = newHealthBarColor;

            StrokeBarImage.color = Color.black;
            BackgroundBarImage.color = newBackgroundBarColor;
        }
        else if (CharacterData.Character == RostykEnums.Characters.Romario)
        {
            PlayerIcon.sprite = RomarioIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#B00000", out Color newHealthBarColor);
            UnityEngine.ColorUtility.TryParseHtmlString("#787878", out Color newBackgroundBarColor);
            HealthBarImage.color = newHealthBarColor;

            StrokeBarImage.color = Color.black;
            BackgroundBarImage.color = newBackgroundBarColor;
        }
        else if (CharacterData.Character == RostykEnums.Characters.Panini)
        {
            PlayerIcon.sprite = PaniniIcon;
            HealthBarImage.color = Color.black;
            UnityEngine.ColorUtility.TryParseHtmlString("#959595", out Color newBackgroundBarColor);

            StrokeBarImage.color = Color.white;
            BackgroundBarImage.color = newBackgroundBarColor;
        }
    }
}
