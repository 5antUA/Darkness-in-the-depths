using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    private Player MyPlayer;
    private Text PlayerInfo;


    void Start()
    {
        MyPlayer = GetComponentInParent<Player>();
        PlayerInfo = GetComponentInChildren<Text>();
    }

    void Update()
    {
        PlayerInfo.text =
            $"Health : {MyPlayer.Health}\n" +
            $"Gamemode : {MyPlayer.GameMode}\n" +
            $"WeaponMode : - \n" +
            $"Weapon : - ";
    }
}
