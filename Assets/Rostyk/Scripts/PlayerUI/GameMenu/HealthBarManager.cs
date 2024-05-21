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
    private SavedData.InputData InputData;

    public GameObject HealthBar;
    public Image AmountHealthImage;

    [Space]
    public Text PlayerInfo;                                    // информация об игроке (Text UI)
    public GameObject MenuUI;                                  // MenuUI
    private Player MyPlayer;                                   // скрипт this.Player


    private void Awake()
    {
        InputData = new SavedData.InputData();
        InputData = InputData.Load();
    }
    private void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
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
        AmountHealthImage.fillAmount = MyPlayer.Health / 100f;

        if (MyPlayer.IsDead)
            healthInfo = 0;

        PlayerInfo.text =
            $"Health : {healthInfo}\n";
    }
}
