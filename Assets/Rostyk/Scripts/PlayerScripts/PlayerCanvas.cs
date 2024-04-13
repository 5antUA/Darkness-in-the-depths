using UnityEngine;
using UnityEngine.UI;


// ¬≈ÿ¿“‹ — –»œ Õ¿ Œ¡⁄≈ “ PlayerUI
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
        UpdatePlayerInfo();
    }

    private void UpdatePlayerInfo()
    {
        PlayerInfo.text =
            $"Health : {MyPlayer.Health}\n" +
            $"Gamemode : {MyPlayer.GameMode}\n" +
            $"WeaponMode : - \n" +
            $"Weapon : - ";
    }
}
