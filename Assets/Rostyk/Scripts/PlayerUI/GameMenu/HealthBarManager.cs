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
    private SavedData.InitializationData InitializationData;
    private SavedData.InputData InputData;

    public GameObject HealthBar;

    [Space]
    public Text PlayerInfo;                                    // информация об игроке (Text UI)
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // скрипт this.Player

    [Header("\t Initialition data")]
    [Space]
    [SerializeField] private Image AmountHealthImage;
    [SerializeField] private Image PlayerIcon;

    [SerializeField] private Sprite KovalevIcon;
    [SerializeField] private Sprite RadchenkoIcon;
    [SerializeField] private Sprite ValentinIcon;


    private void Awake()
    {
        InitializationData = new SavedData.InitializationData();
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
        AmountHealthImage.fillAmount = MyPlayer.Health / MyPlayer.MaxCharacterHealth;

        if (MyPlayer.IsDead)
            healthInfo = 0;

        PlayerInfo.text =
            $"Health : {healthInfo}\n";
    }

    private void InitData()
    {
        if (InitializationData.Character == RostykEnums.Characters.Kovalev)
        {
            PlayerIcon.sprite = KovalevIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#0B8C00", out Color newColor);
            AmountHealthImage.color = newColor;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Radchenko)
        {
            PlayerIcon.sprite = RadchenkoIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#00A8FF", out Color newColor);
            AmountHealthImage.color = newColor;
        }
        else if (InitializationData.Character == RostykEnums.Characters.Valentin)
        {
            PlayerIcon.sprite = ValentinIcon;
            UnityEngine.ColorUtility.TryParseHtmlString("#BC2900", out Color newColor);
            AmountHealthImage.color = newColor;
        }
    }
}
