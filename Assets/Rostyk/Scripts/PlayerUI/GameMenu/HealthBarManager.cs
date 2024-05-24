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
    private SavedData.CharacterData InitializationData;
    private SavedData.InputData InputData;

    public GameObject HealthBar;

    [Space]
    public Text PlayerInfo;                                    // информация об игроке (Text UI)
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // скрипт this.Player

    [Header("\t Initialition data")]
    [Space]
    [SerializeField] private Text PlayerInfoText;
    [SerializeField] private Image StrokeBarImage;
    [SerializeField] private Image HealthBarImage;
    [SerializeField] private Image PlayerIcon;

    [SerializeField] private Sprite KovalevIcon;
    [SerializeField] private Sprite ValentinIcon;
    [SerializeField] private Sprite RomarioIcon;
    [SerializeField] private Sprite PaniniIcon;


    private void Awake()
    {
        InitializationData = new SavedData.CharacterData();
        InputData = new SavedData.InputData();
        InitializationData = InitializationData.Load();
        InputData = InputData.Load();
    }
    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        InitData();
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

        PlayerInfo.text =
            $"Health : {healthInfo}\n";
    }

    private void InitData()
    {
        if (InitializationData.Character == RostykEnums.Characters.Valentin)
        {
            PlayerIcon.sprite = ValentinIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#0B8C00", out Color newColor);
            HealthBarImage.color = newColor;

            StrokeBarImage.color = Color.black;
            PlayerInfo.color = Color.black;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Kovalev)
        {
            PlayerIcon.sprite = KovalevIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#007BFF", out Color newColor);
            HealthBarImage.color = newColor;

            StrokeBarImage.color = Color.black;
            PlayerInfo.color = Color.black;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Romario)
        {
            PlayerIcon.sprite = RomarioIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#FF0500", out Color newColor);
            HealthBarImage.color = newColor;

            StrokeBarImage.color = Color.black;
            PlayerInfo.color = Color.black;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Panini)
        {
            PlayerIcon.sprite = PaniniIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#BC2900", out Color newColor);
            HealthBarImage.color = Color.black;

            StrokeBarImage.color = Color.white;
            PlayerInfo.color = Color.white;
        }
    }
}
